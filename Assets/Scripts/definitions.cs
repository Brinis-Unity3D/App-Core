using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class IdentityInfo
{
    public string id = "noID";
    public string name;
    public string phoneNumber;
    public Vector2 gpsPosition;
    public List<Vote> votes = new List<Vote>();
}

[System.Serializable]

public class Client: IdentityInfo
{
  
    public string lastName;
    public string CIN;
    public List<Placement> history=new List<Placement>();
    public string InstitutionID = null;
    public string email;
    public int index;
}
[System.Serializable]
public class Relation
{
    public string station;
    public string client;
    public int index;
    public System.DateTime date;
}
[System.Serializable]
public class Placement
{
    public Relation relation = new Relation();
}
[System.Serializable]
public class Vote
{
    public Relation relation = new Relation();
}
[System.Serializable]
public class ServiceStation:IdentityInfo
{
   
   
    public string image;
    public int windowNumber = 1;
    public string description;
    public List<string> agents = new List<string>();
    public int currentIndex=0;
    public int currentLast=0;
    public List<Placement> clientsListForToday = new List<Placement>();
    public List<Placement> clientsListHistory = new List<Placement>();

}
[System.Serializable]
public class Institution: IdentityInfo
{
    public string owner;
    List<ServiceStation> allServices = new List<ServiceStation>();
}
