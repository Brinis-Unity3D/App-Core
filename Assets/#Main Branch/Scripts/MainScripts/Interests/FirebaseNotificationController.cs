using UnityEngine;

public class FirebaseNotificationController : MonoBehaviour
{
    public static FirebaseNotificationController instance;
    public GameObject InterestsPanel;
    public GameObject languageFirstPanel;
    public GameObject mainPanel;

    void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey(LanguageSetController.ChosenLanguageKey))
        {
            language = (LanguageEnum)PlayerPrefs.GetInt(LanguageSetController.ChosenLanguageKey);
            languageFirstPanel.SetActive(false);
            mainPanel.SetActive(true);
        }
        else
        {
            language = LanguageEnum.English;
            languageFirstPanel.SetActive(true);
        }
    }
    #if !UNITY_WEBGL
    public void Start()
    {   
        Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
        Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
     //   Firebase.Messaging.FirebaseMessaging.Subscribe("/topics/example");
       
        /* if (Application.systemLanguage == SystemLanguage.English)
         {
             Debug.Log("This system is in English. ");
             language = Languages.EN;
         }
         if (Application.systemLanguage == SystemLanguage.Chinese)
         {
             Debug.Log("This system is in Chinese. ");
             language = Languages.CH;
         }
         if (Application.systemLanguage == SystemLanguage.French)
         {
             Debug.Log("This system is in French. ");
             language = Languages.FR;
         }

         if (Application.systemLanguage == SystemLanguage.German)
         {
             Debug.Log("This system is in Arabic. ");
             language = LanguageEnum.German;
         }*/
      //  Firebase.Messaging.FirebaseMessaging.Subscribe("/topics/"+language);
    }
    public void UnsubscribeToAllAndSubscribeToNew(LanguageEnum newLanguage)
    {
        Firebase.Messaging.FirebaseMessaging.UnsubscribeAsync("/topics/" + language);
        
        FirebaseNotificationController.language = (LanguageEnum)newLanguage;
        InterestsPanel.gameObject.SetActive(true);
        InterestsPanel.gameObject.SetActive(false);
       

    }
    public static LanguageEnum language;
    public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token)
    {
        Debug.Log("Received Registration Token: " + token.Token);
    }

    public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
    {
        Debug.Log("Received a new message from: " + e.Message.From);
    }
#endif
}
