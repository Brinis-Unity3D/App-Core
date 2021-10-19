using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using brinis;

public class RoomChangeController : MonoBehaviour
{
    public Room roomToModify = new Room();
    
    
    public void ChangeStatu(int statu)
    {
        roomToModify.status =(RoomStatus)statu;
        ListingManager.Save<Room>(roomToModify);
        gameObject.SetActive(false);
    }

    public void Put()
    {
        //roomToModify.id = "testID" + Random.Range(-100, 100);
        ListingManager.PutFormularToDatabase<Room>(transform,roomToModify);
        gameObject.SetActive(false);
    }
    void OnEnable()
    {
       
    }

}
