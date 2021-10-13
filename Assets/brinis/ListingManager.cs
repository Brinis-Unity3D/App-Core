using Firebase;

using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


// Conventions :
// prefab should has childrenwith names of class parameters else text will not be setted
// other suggested changes can be done in OnEnable() of a scripe named "RoomController" cause the type traited is Room , the 'C' should be UpperCase
// using the automatic stored data in "info" parameter
namespace brinis
{
    public class ListingManager : MonoBehaviour
    {
        public string key;
        public static ListingManager instance;
        public static MonoBehaviour trustedObject;
        public static bool canWork = true;
        public string realTimeBaseURI= "https://virtual-saf-default-rtdb.firebaseio.com";

      /*  public delegate void OnNewUpdateFromDatabase<T>(Dictionary<string, T> allInfos);
        public OnNewUpdateFromDatabase<T> onUpdate = new OnNewUpdateFromDatabase<T>();*/


        void Awake()
        {
            instance = this;
            trustedObject = this;
            // trustedObject.StartCoroutine(SubscribeManager.FetchKey());
          //  FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(realTimeBaseURI);
        }

        public static DatabaseReference reference;
        IEnumerator Start()
        {
           
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return new WaitForSeconds(1);

            print("after yield");
           /* AppOptions options = new AppOptions();
            options.DatabaseUrl = new System.Uri(realTimeBaseURI);
            FirebaseApp app = FirebaseApp.Create(options);
           */
           

            while (!FirebaseBehavior.instance) yield return null;
            while (FirebaseBehavior.instance.reference==null) yield return null;
            print("getting ref from FirebaseBehavior.instance");
            reference = FirebaseBehavior.instance.reference;
            
        }






        public static void PutFormularToDatabase<T>(Transform formularHead, System.Object t)
        {
            if (!canWork)
            {
                Debug.LogError("you are not subscribed to the Listing Manager");
                return;
            }
            t =EasyCrudsManager.GetInfoAutomaticly<T>(formularHead,t);
            Save<T>((T)t);
        }

        public static void Save<T>(object t)
        {
            if (!canWork)
            {
                Debug.LogError("you are not subscribed to the Listing Manager");
                return;
            }
            string id = "" + t.GetType().GetField("id").GetValue(t);
            if (string.IsNullOrWhiteSpace(id))
            {
                Debug.LogError("id is null for the object of type " + t.GetType());
                return;
            }
            reference.Root.Child(EasyCrudsManager.TableName<T>()).Child(t.GetType().ToString()[0] + id).SetRawJsonValueAsync(JsonConvert.SerializeObject(t));
        }
        public static void AllPrefabsCheckTable<T>(Transform prefab)
        {
            if (EasyCrudsManager.allPrefabs == null)
            {
                EasyCrudsManager.allPrefabs = new Dictionary<string, Transform>();
            }
            if (!EasyCrudsManager.allPrefabs.ContainsKey(EasyCrudsManager.TableName<T>()))
            {
                EasyCrudsManager.allPrefabs.Add(EasyCrudsManager.TableName<T>(), prefab);
            }
        }

        public static void SyncTableFromDatabase<T>(Transform prefab)
        {

            AllPrefabsCheckTable<T>(prefab);
            if (PlayerPrefs.HasKey(EasyCrudsManager.TableName<T>()))
            {
                brinis.EasyCrudsManager.allTables[EasyCrudsManager.TableName<T>()] =
                    
                    JsonConvert.DeserializeObject<Dictionary<string,object>>(
                    PlayerPrefs.GetString(EasyCrudsManager.TableName<T>()).Replace("\\", "")
                    );
                StringJsonToCanvas<T>(PlayerPrefs.GetString(EasyCrudsManager.TableName<T>()));
            }
            trustedObject.StartCoroutine(WaitForKeyThenSubScribe<T>());

        }

        static IEnumerator WaitForKeyThenSubScribe<T>()
        {
            Debug.LogWarning("WaitForKeyThenSubScribe " + typeof(T));
            yield return null;
            while (reference==null)
            {
                Debug.LogWarning("waiting  reference at " + instance.name);
                yield return new WaitForSeconds(1);
            }
            reference.Root
      .Child(EasyCrudsManager.TableName<T>())
     .ValueChanged += HandleValueChanged<T>;

        }
        public static void SyncTableFromDatabaseWithConditions<T>(Transform prefab, string key, string value, string key2 = null, string value2 = null)
        {
            AllPrefabsCheckTable<T>(prefab);
            //   Ticket t = new Ticket();
            if (key2 != null)
            {
                reference.Root
     .Child(EasyCrudsManager.TableName<T>()).OrderByChild(key2).EqualTo(value2).OrderByChild(key).EqualTo(value)
           .ValueChanged += HandleValueChanged<T>;
            }
            else
            {
                reference.Root
      .Child(EasyCrudsManager.TableName<T>()).OrderByChild(key).EqualTo(value)
               .ValueChanged += HandleValueChanged<T>;
            }
            //t.service
            /*if (typeof(T).(v.na()+"") != null)
            {
              if(T.GetField(v.GetType() + "").GetValue(t)==v)
                {

                }
            }*/
        }

        void OnDestroy()
        {
            //FirebaseDatabase.DefaultInstance.
            foreach (string k in EasyCrudsManager.allPrefabs.Keys)
            {
                reference.Root
      .Child(k)
              .ValueChanged -= HandleValueChanged<Type>;
            }

        }
        static void HandleValueChanged<T>(object sender, ValueChangedEventArgs args)
        {
           // Debug.Log("HandleValueChanged " + args.Snapshot.GetRawJsonValue());
            if (args.DatabaseError != null)
            {
                Debug.LogError(args.DatabaseError.Message);
                return;
            }
            PlayerPrefs.SetString(EasyCrudsManager.TableName<T>(),args.Snapshot.GetRawJsonValue());
            StringJsonToCanvas<T>(args.Snapshot.GetRawJsonValue());
        }

        public static void StringJsonToCanvas<T>(string json, System.Func<Dictionary<string, T>, Dictionary<string, T>> lastMovesCallBack = null)
        {
            //Debug.Log("string to canvas for " + json);
            if (string.IsNullOrWhiteSpace(json)) return;
            if (!EasyCrudsManager.allTables.ContainsKey(EasyCrudsManager.TableName<T>()))
                EasyCrudsManager.allTables.Add(EasyCrudsManager.TableName<T>(), null);

            EasyCrudsManager.allTables[EasyCrudsManager.TableName<T>()] = JsonConvert.DeserializeObject<Dictionary<string,T>>(json).ToDictionary(k => k.Key, k => (object)k.Value);
            if (!canWork)
            {
                Debug.LogError("you are not subscribed to the Listing Manager");
            }
            else
            {
                if (EasyCrudsManager.allPrefabs.ContainsKey(EasyCrudsManager.TableName<T>()))
                    trustedObject.StartCoroutine(EasyCrudsManager.ShowAll<T>(EasyCrudsManager.allPrefabs[EasyCrudsManager.TableName<T>()], EasyCrudsManager.allTables[EasyCrudsManager.TableName<T>()].ToDictionary(k => k.Key, k => (T)k.Value),lastMovesCallBack));
                else
                    Debug.Log("no prefab for " + EasyCrudsManager.TableName<T>());
            }
        }
        static WaitForSeconds w = new WaitForSeconds(0.001f);

     

  
        public static Dictionary<string,T> GetWholeTable<T>()
        {
            if(EasyCrudsManager.allTables.ContainsKey(EasyCrudsManager.TableName<T>()))
            {
                return EasyCrudsManager.allTables[EasyCrudsManager.TableName<T>()].ToDictionary(k => k.Key, k => (T)k.Value);
            }else
            {
                trustedObject.StartCoroutine(WaitForKeyThenSubScribe<T>());
                return null;
            }
            
            //allTables[EasyCrudsManager.TableName<T>()] = allInfos.ToDictionary(k => k.Key, k => (object)k.Value);
        }
        public static T Load<T>(string id)
        {
            if (EasyCrudsManager.allTables.ContainsKey(EasyCrudsManager.TableName<T>()))
            {
                if (!EasyCrudsManager.allTables[EasyCrudsManager.TableName<T>()].ContainsKey(typeof(T).ToString()[0] + id)) return default(T);
                return (T)EasyCrudsManager.allTables[EasyCrudsManager.TableName<T>()][typeof(T).ToString()[0] + id];
            }
            else
            {
                trustedObject.StartCoroutine(WaitForKeyThenSubScribe<T>());
                return default(T);
            }
            
        }
        public static Dictionary<string, T>  LoadTable<T>()
        {
            if (EasyCrudsManager.allTables.ContainsKey(EasyCrudsManager.TableName<T>()))
            {

                Dictionary<string, T> newDictionary = new Dictionary<string, T>();

                foreach (string key in EasyCrudsManager.allTables[EasyCrudsManager.TableName<T>()].Keys)
                    newDictionary.Add(key,(T) EasyCrudsManager.allTables[EasyCrudsManager.TableName<T>()][key]);
                return newDictionary;
            }
            else
            {
                trustedObject.StartCoroutine(WaitForKeyThenSubScribe<T>());
                return default(Dictionary<string, T>);
            }

        }


    }
}
