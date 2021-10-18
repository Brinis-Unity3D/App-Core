using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class callThisNumber : MonoBehaviour
{

    public string tel;
    public void CallThisNumber()
    {
        if (GetComponentInChildren<Text>())
            tel = GetComponentInChildren<Text>().text;

        Application.OpenURL("tel:"+tel);
    }
}
