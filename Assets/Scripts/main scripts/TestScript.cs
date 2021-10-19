using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField email;
    public GameObject other;
    void Start()
    {
        Debug.Log("first frame at " + name);
        //email.gameObject.SetActive(false);
      // other.transform.position -= Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update frame at " + name+" t: "+Time.realtimeSinceStartup);
        other.transform.localPosition -= Vector3.one*Time.deltaTime;
    }
}
