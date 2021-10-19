using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager instance;
    public static bool isForGouvernante = false;
    void Awake()
    {
        instance = this;
    }
   
}
