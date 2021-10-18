using Firebase;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.Reflection;
using UnityEngine.UI;
using brinis;

public class RoomsListManager : MonoBehaviour
{
    public RoomController roomPrefab,roomInstance;
    public static Dictionary<string, Room> allRooms = new Dictionary<string, Room>();
    public  Dictionary<string, Room> allRoomController = new Dictionary<string, Room>();

    public  DatabaseReference reference;
    void Start()
    {
        // Set up the Editor before calling into the realtime database.

        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
      // GetInfo();
        string json = JsonConvert.SerializeObject(allRooms);
        Debug.Log(EasyCrudsManager.TableName<Room>());
        //reference.Child(ListingManager.TableName<Room>()).SetRawJsonValueAsync(json);
        Debug.Log(nameof(Room.comment));
        ListingManager.SyncTableFromDatabase<Room>(roomPrefab.transform);
      //  ListingManager.ShowAll(roomPrefab.transform,allRooms);
    }
  
   

    void GetInfo()
    {
        allRooms.Clear();
       
        for(int i = 100;i<120;i++)
        {
            Room r = new Room();
            r.id = i+"";
            r.status =(RoomStatus)UnityEngine.Random.Range(0,2);
            r.adultNumber = UnityEngine.Random.Range(1, 3);
            allRooms.Add("R"+r.id, r);
        }
      
    }
   
}
