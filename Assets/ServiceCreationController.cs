using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceCreationController : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TMP_InputField nameField, phone,guichet;
    public ServiceStation service = new ServiceStation();
    private void Start()
    {
       
        print("FirebaseBehavior name = " + FindObjectOfType<FirebaseBehavior>().name);
        //CreateService();
        Invoke("DoAfterTime", 2);
        Invoke("DoAfterTime", 3);
    }
    void DoAfterTime()
    {
       
       // CreateService();
        
      
    }
    public void CreateService()
    {
        service = new ServiceStation();
        service.id = DateTime.UtcNow.ToString("yyyy_MM_dd_hh_mm_ss");
       // service.name = nameField.text;
        //service.phoneNumber = phone.text;
        //int.TryParse(guichet.text,out service.windowNumber);
        service.agents.Add(UserManager.instance.user.email);
        service=brinis.EasyCrudsManager.GetInfoAutomaticly<ServiceStation>(transform,service);
        GetComponent<QRCodeGenerator>().GenerateQRCode(SecurityManager.Base64Encode(JsonConvert.SerializeObject(service)),service);
        brinis.ListingManager.Save<ServiceStation>(service);
    }
}
