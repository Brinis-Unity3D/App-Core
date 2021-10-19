using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutListerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    void Start()
    {
        Dictionary<string, UserTest> allUsers = new Dictionary<string, UserTest>();
        allUsers.Add("aa", new UserTest());
        allUsers.Add("ab", new UserTest());
        allUsers.Add("ac", new UserTest());
        allUsers.Add("ad", new UserTest());
      StartCoroutine(brinis.EasyCrudsManager.ShowAll<UserTest>(prefab.transform, allUsers));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
