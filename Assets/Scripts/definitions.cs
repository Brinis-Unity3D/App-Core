using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Client
{
    public string name;
    public string lastName;
    public string CIN;
    public string phoneNumber;
    public Vector2 gpsPosition;
    public List<Placement> history=new List<Placement>();
    public List<Vote> votes = new List<Vote>();
    public string image;
}
[System.Serializable]
public class Relation
{
    public string station;
    public string client;
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
public class Station
{
    public string name;
    public string id;
    public string image;
    public Vector2 gpsPosition;
    public List<Placement> clientsListForToday = new List<Placement>();
    public List<Placement> clientsListHistory = new List<Placement>();

}
