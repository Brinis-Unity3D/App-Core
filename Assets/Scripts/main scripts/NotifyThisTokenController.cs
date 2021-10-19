using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotifyThisTokenController : MonoBehaviour
{
    public string token;
    public void NotifyThisClient()
    {
        if (GetComponentInChildren<Text>())
            token = GetComponentInChildren<Text>().text;
        NotifInfo notif = new NotifInfo();
        notif.title = "test";
        notif.body = "test body"+System.DateTime.Now;
        NotificationEmetter.instance.SendMessageToTopic(token, notif);

        NotificationEmetter.instance.SendMessageToTopic2(token, notif);
    }
}
