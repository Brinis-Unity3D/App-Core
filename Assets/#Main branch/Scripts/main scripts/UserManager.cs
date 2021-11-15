using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UserManager instance;
    public FirebaseUser userFirebase;
    public Client user=new Client();
    public Transform UserPrefab;
    private void Awake()
    {
        instance = this;
        brinis.ListingManager.SyncTableFromDatabase<UserInfo>(UserPrefab);
    }

    public void SetUser(FirebaseUser userFromFirbase)
    {
        user.email = userFromFirbase.Email;
        user.name = userFromFirbase.DisplayName;
        user.id = userFromFirbase.UserId;
        if(brinis.ListingManager.Load<Client>(user.id)!=null)
        user = brinis.ListingManager.Load<Client>(user.id);
        print("");
    }
    public void SaveUser()
    {
        brinis.ListingManager.Save<Client>(user);
    }
    public void SaveOtherUser(Client otherUser)
    {
        brinis.ListingManager.Save<Client>(otherUser);
    }


  
    public bool ShouldShow(UserInfo user)
    {
        return !string.IsNullOrWhiteSpace(user.tel);
    }

  
}
