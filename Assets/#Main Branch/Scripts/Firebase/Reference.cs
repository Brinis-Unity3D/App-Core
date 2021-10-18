using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;



public class Reference : MonoBehaviour
{
    DatabaseReference reference;
    void Start()
    {
        // Set up the Editor before calling into the realtime database.


        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        Debug.Log("initialized");
    }
    private void writeNewClient(ClientInfo myClient)
    {
       // ClientInfo customer = new ClientInfo(myClient.nom,  prenom,  dateNaiss,  lieu,  nationalite,  profession,  domicile,  email,  tel,  venantDe,  allantA,  entreLe,  dateDep,  PassOrCIN,  num,  delivreLe,  a,  par,  numChambre);
        string json = JsonUtility.ToJson(myClient);
        reference.Child("AllCustomers").Child(myClient.nom+myClient.prenom).SetRawJsonValueAsync(json);
    }
}
