using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UserManager instance;
    public FirebaseUser userFirebase;
    public UserInfo user;
    public void SetUser(FirebaseUser userFromFirbase)
    {
        user.email = userFromFirbase.Email;
        user.name = userFromFirbase.DisplayName;
        user.id = userFromFirbase.UserId;
        user = brinis.ListingManager.Load<UserInfo>(user.id);
    }
    public void SaveUser()
    {
        brinis.ListingManager.Save<UserInfo>(user);
    }
    public void SaveOtherUser(UserInfo otherUser)
    {
        brinis.ListingManager.Save<UserInfo>(otherUser);
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

  
}
