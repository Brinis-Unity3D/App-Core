using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using Firebase;
using Firebase.Database;

using Newtonsoft.Json;

public class CustomersList : MonoBehaviour
{
    DatabaseReference reference;
    public Text customerListText;
    //public GameObject myObjToInstantiate;


    // Start is called before the first frame update
    void Start()
    {
      
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void getAllCustomers()
    { 
        FirebaseDatabase.DefaultInstance.GetReference("AllCustomers").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.Log("No snapshot");
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                //Debug.Log("Snapshot:= " + task.Result.Value);
                int i = 0;
                foreach (DataSnapshot user in snapshot.Children)
                {
                    // IDictionary dictUser = (IDictionary)user.Value;
                    //Debug.Log(dictUser.Keys);
                    ClientInfo client = JsonConvert.DeserializeObject<ClientInfo>(user.GetRawJsonValue());
                    //Debug.Log("Pass/CIN: " + dictUser["PassOrCIN"] + " Num°: " + dictUser["num"]);
                    Debug.Log("Pass/CIN: " + client.PassOrCIN + " Num°: " + client.num);
                    Debug.Log(user.GetRawJsonValue());
                    customerListText.text = user.GetRawJsonValue();
                }
            }

        });



    }
}
