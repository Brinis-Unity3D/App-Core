using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class callThisNumber : MonoBehaviour
{
 
    public void CallThisNumber()
    {
        Application.OpenURL("tel:"+GetComponent<Text>().text);
    }
}
