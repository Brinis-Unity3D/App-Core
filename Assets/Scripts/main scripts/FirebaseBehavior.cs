using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class FirebaseBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public DatabaseReference reference;
    public FirebaseAuth auth;
    public FirebaseUser user;
    public PhoneAuthProvider provider;
    public InputField phoneNumber;
    public static FirebaseBehavior instance;
  
    private void Awake()
    {
        instance = this;
    }
    IEnumerator Start()
    {

         yield return null;
         yield return null;
         yield return null;
         yield return null;
         yield return null;
         yield return null;
         yield return null;
         yield return null;
         yield return new WaitForSeconds(1);
        
        // FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://virtual-saf-default-rtdb.firebaseio.com");
        InitializeFirebase();
#if UNITY_MOBILE
        reference = FirebaseDatabase.DefaultInstance.RootReference;

#else
        yield return null;
        while (reference == null)
        {
            AppOptions options = new AppOptions();
            options.DatabaseUrl = new System.Uri("https://virtual-saf-default-rtdb.firebaseio.com");
            FirebaseApp app = FirebaseApp.Create(options);
            reference = FirebaseDatabase.GetInstance(app, "https://virtual-saf-default-rtdb.firebaseio.com").RootReference;
            yield return null;
            yield return null;


        }
#endif


    }
    void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
        provider = PhoneAuthProvider.GetInstance(auth);
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
        

    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + JsonUtility.ToJson(user.UserId));

            }
        }
    }





  




}
