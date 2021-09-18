using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetChamberNum : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = PlayerPrefs.GetString("Room");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
