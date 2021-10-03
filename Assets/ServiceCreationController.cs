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
        Invoke("DoAfterTime", 2);
        Invoke("DoAfterTime", 3);
    }
    void DoAfterTime()
    {
        UserInfo user = new UserInfo();
        user.id = "ss";
        brinis.ListingManager.Save<UserInfo>(user);
        CreateService();
        
      
    }
    public void CreateService()
    {
        service = new ServiceStation();
        service.id = DateTime.UtcNow.ToString("yyyy_mm_dd_hh_mm_ss");
        service.name = nameField.text;
        service.phoneNumber = phone.text;
        int.TryParse(guichet.text,out service.windowNumber);
        service.agents.Add(UserManager.instance.user.email);
        service=brinis.EasyCrudsManager.GetInfoAutomaticly<ServiceStation>(transform,service);
        GetComponent<QRCodeGenerator>().GenerateQRCode(SecurityManager.Base64Encode(JsonConvert.SerializeObject(service)));
        brinis.ListingManager.Save<ServiceStation>(service);
    }
}
