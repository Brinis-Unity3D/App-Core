﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FingerTouch : MonoBehaviour
{
    public GameObject theObjectToHide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            theObjectToHide.SetActive(false);
        }
    }
}
