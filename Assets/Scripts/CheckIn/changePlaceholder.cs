using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePlaceholder : MonoBehaviour
{
    public Color defaultColor;
    void Awake()
    {
        
        defaultColor = GetComponent<Text>().color;
       //Debug.Log("color= " + defaultColor.ToString());
    }
    private void OnEnable()
    {
        //Debug.Log("Place holder ancien = " + transform.parent.GetComponent<InputField>().placeholder);
        //transform.parent.GetComponent<InputField>().placeholder = GetComponent<Text>();
        //Debug.Log("Place holder nouveau= "+ transform.parent.GetComponent<InputField>().placeholder);
        //GetComponent<Text>().color = defaultColor;
        changePlaceHolder();
        Invoke("changePlaceHolder",0.1f);
        
     }

    void changePlaceHolder()
    {
        if (transform.parent.GetComponent<InputField>().placeholder.IsActive())
        {
            return;
        }
        transform.parent.GetComponent<InputField>().placeholder = GetComponent<Text>();
        
        GetComponent<Text>().color = defaultColor;
    }
}
