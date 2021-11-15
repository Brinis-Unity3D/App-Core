
using Firebase.Messaging;
using UnityEngine;


public  class NotificationsManager : MonoBehaviour
    {
        public void  Start()
        {
            FirebaseMessaging.TokenRegistrationOnInitEnabled = true;
            Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
            Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
            
           // FirebaseMessaging.GetTokenAsync();
    }

    public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token)
        {
            UnityEngine.Debug.Log("Received Registration Token: " + token.Token);
            StartCoroutine(LoginManager.instance.SaveTocken(token.Token));
        }

        public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
        {
            UnityEngine.Debug.Log("Received a new message from: " + e.Message.From);
        }
    }
public class NotifInfo
{
    public string topicID;
    public string title;
    public string body;
}
