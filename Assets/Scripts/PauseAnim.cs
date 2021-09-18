using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAnim : MonoBehaviour
{
    public GameObject myObj;
    public void AnimManager ()
    {
        if (myObj.GetComponent<Animator>().isActiveAndEnabled)
        {
            myObj.GetComponent<Animator>().enabled = false;
            Debug.Log("Im stoping");
        }
        else myObj.GetComponent<Animator>().enabled = true;
        Debug.Log("Im playing back");
    }
}
