using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityManager : MonoBehaviour
{
    // Start is called before the first frame update
    public ServiceStation service;
    void Start()
    {
       Debug.Log(" encode = " + Base64Encode("brinis"));
      // Debug.Log(" decode = " + Base64Decode("brinis"));
       Debug.Log(" decodeEncode = " + Base64Decode(Base64Encode("brinis")));
        service.id = Base64Encode(service.id);
        Debug.Log("service json = "+JsonUtility.ToJson(service));
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
}
