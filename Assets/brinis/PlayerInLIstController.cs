using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInLIstController : MonoBehaviour
{
    // Start is called before the first frame update
    public   UserTest user = new UserTest();
    void Start()
    {
        brinis.EasyCrudsManager.SetTextAutomaticly<UserTest>(transform,user);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class UserTest
{
    public string name;
    public int score = 10;
    public int rank = 5;
    public int money = 5000;
    public string imageVar;
}
