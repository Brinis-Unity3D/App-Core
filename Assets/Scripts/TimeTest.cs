using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTest : MonoBehaviour
{
    DateTime now;
    DateTime from;
    DateTime to;
    //public Text testOpen;
    public Image imageOpen;
    public Sprite spriteOpen;
    public string timeToOpen;
    public string timeToClose;

    void Update ()
    {
        now = System.DateTime.UtcNow;

        from = Convert.ToDateTime(timeToOpen);
        to = Convert.ToDateTime(timeToClose);

        if ((now.CompareTo(from) >= 0) && (now.CompareTo(to) <= 0))
        {
            //testOpen.text = "Open";
            imageOpen.GetComponent<Image>().sprite = spriteOpen;
        }
        
       // Debug.Log("Now= "+now);
       // Debug.Log("To= "+to);
       // Debug.Log("From= "+from);
        //Debug.Log("Compare to: "+now +" "+ to +" "+ now.CompareTo(to));
       // Debug.Log("Compare from: "+now +" "+ to +" "+ now.CompareTo(from));
       // Debug.Log("Result" + ((now.CompareTo(from) >= 0) && (now.CompareTo(to) <= 0)));
    }
}
