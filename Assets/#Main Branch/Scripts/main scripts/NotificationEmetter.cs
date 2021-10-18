using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NotificationEmetter : MonoBehaviour
{
    public static NotificationEmetter instance;

    string key= "AAAAV_G7c2s:APA91bEquS5KJZIO7AUw1bsEw9Kj7faBk-xoGz4UmBDGQ_F9inPPEPmb4K59DrYuZivNeauqaxz8yKG4VDrgTn-5JKtbV02rf17ntFMSI3Vzz7fJQDFh5v4qXofJKLeWcJjCl45JhKuU", 
        sender= "377717748587";
    string webkey = "BFr84Ps2M5g_oPMyfnX9_Hmpo-7-yFVw6VVgqApQeYw6Hs7EtREXd_usy5nltqUAJnRDbx-v74_lyOkm6HPj0M8";
    void Awake()
    {
        instance=this;
    }
    public static string InterestsToTopic(string interest, string language)
    {
        string pivot = interest + language;
        pivot=pivot.Replace(" ","");
        //Debug.Log("InterestsToTopic " + pivot);
        return pivot;
    }
    public void BroadCastNotification()
    {
        //Debug.Log("lang name = " + AdminProgrammeManager.language.name);
      
        //SendMessageToTopic("example", pr);
      //  SendMessageToTopic( InterestsToTopic(interest.options[interest.value].text), pr);
       /* if (interest.options[interest.value].text+"" != Interests.Other+"")
        {
            Debug.Log(" "+interest.options[(int)Interests.Other].text+"");
            SendMessageToTopic(
            InterestsToTopic(Interests.Other+"", AdminProgrammeManager.language.options[AdminProgrammeManager.language.value].text + "")
            , pr);
        }*/
    }
    IEnumerator SendNotifROutine(string topic,NotifInfo info)
    {
        WWWForm form = new WWWForm();
        Dictionary<string, string> headers = new Dictionary<string, string>();
        // UnityWebRequest tRequest = new UnityWebRequest("https://fcm.googleapis.com/fcm/send");
        //WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
        // tRequest.method = "post";
        //  tRequest.SetRequestHeader("Authorization", "AAAAJTkHlQ8:APA91bEsHMzYP8KA9ZD2jK2qr47cTUX53rb5qy-IVgEKjqdj3AjS43V8Oshb8ix_ZZez4TOBaAY-LcKxfUJA4bE4s-9abkvO00YCur5d0BtS64r4uAQ5QtnBarkJ4owgtVEmZ4IGNSoK");
        //Sender Id - From firebase project setting  
        //tRequest.SetRequestHeader("Sender", "159870588175");
        //   tRequest.SetRequestHeader("ContentType", "application/json");
        
        headers.Add("Authorization", "key="+key);
        headers.Add("Sender", "id="+sender);
        headers.Add("Content-Type", "application/json");
        //  form.AddField("method","post");
        //serverKey - Key from Firebase cloud messaging server  

        //  tRequest.ContentType = "application/json";
        var payload = new
        {
             to =  topic,
            //condition = "'" + "otherr" + "' in topics || '" + topic + "' in tokens",
            priority = "high",
            content_available = true,
            notification = new
            {
                to = topic,
                body = info.body,
                title = info.title,
                badge = 1,
                android_channel_id = topic + "",
                tag = topic + "",
                color = "#C0AF23",
                sound = "ss"
              

            },
           android=  new {
               collapse_key= "1",
               sound = "ss",
               notification =new
               {
                   sound = "ss"
               }
           },
        };

        string postbody = JsonConvert.SerializeObject(payload).ToString();
        Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
        // tRequest.ContentLength = byteArray.Length;
        //tRequest.uploadHandler = new UploadHandlerRaw(byteArray);
        //form.AddBinaryData("file",byteArray) ;
        WWW www = new WWW("https://fcm.googleapis.com/fcm/send",byteArray, headers) ;
        Debug.Log("headers=" + JsonConvert.SerializeObject(headers));
        
        //yield return tRequest.SendWebRequest();
        yield return www;
        //Debug.Log("www=" + JsonConvert.SerializeObject(www));
        Debug.Log("www= " + www.text);
        /* Debug.Log("handler= "+JsonConvert.SerializeObject( tRequest.downloadHandler));
         Debug.Log("request= "+JsonConvert.SerializeObject( tRequest));
         Debug.Log(tRequest.downloadHandler.text);*/
        /* using (Stream dataStream = tRequest.GetRequestStream())
         //{
           //  dataStream.Write(byteArray, 0, byteArray.Length);
            // using (WebResponse tResponse = tRequest.GetResponse())
             //{
              //   using (Stream dataStreamResponse = tResponse.GetResponseStream())
                 {
                     if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                         {
                             String sResponseFromServer = tReader.ReadToEnd();
                             Debug.Log("response = " + sResponseFromServer);
                             //result.Response = sResponseFromServer;
                         }
                 }
             }
         }*/
    }

    public void SendMessageToTopic(string topic,NotifInfo info)
    {
        StartCoroutine(SendNotifROutine(topic,info));
       
    }
    public void SendMessageToTopic2(string topic,NotifInfo info)
    {
        // unitywe
        WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
        tRequest.Method = "post";
        //serverKey - Key from Firebase cloud messaging server  
        tRequest.Headers.Add(string.Format("Authorization: key={0}", key));
        //Sender Id - From firebase project setting  
        tRequest.Headers.Add(string.Format("Sender: id={0}", sender));
        tRequest.ContentType = "application/json";
        var payload = new
        {
            to =  topic,
            priority = "high",
            content_available = true,
            notification = new
            {
                body =info.body,
                title =info.title,
                badge = 1
            },
        };

        string postbody =
            //JsonUtility.ToJson(payload); 
            JsonConvert.SerializeObject(payload).ToString();
        Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
        tRequest.ContentLength = byteArray.Length;
        using (Stream dataStream = tRequest.GetRequestStream())
        {
            dataStream.Write(byteArray, 0, byteArray.Length);
            using (WebResponse tResponse = tRequest.GetResponse())
            {
                using (Stream dataStreamResponse = tResponse.GetResponseStream())
                {
                    if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String sResponseFromServer = tReader.ReadToEnd();
                            Debug.Log("response = " + sResponseFromServer);
                            //result.Response = sResponseFromServer;
                        }
                }
            }
        }
    }
}

