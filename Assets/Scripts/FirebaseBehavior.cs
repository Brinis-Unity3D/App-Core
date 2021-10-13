using Firebase;
using Firebase.Auth;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirebaseBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public DatabaseReference reference;
    public FirebaseAuth auth;
    public FirebaseUser user;
    public PhoneAuthProvider provider;
    public InputField phoneNumber;
    public static FirebaseBehavior instance;
  
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        /* yield return null;
         yield return null;
         yield return null;
         yield return null;
         yield return null;
         yield return null;
         yield return null;
         yield return null;
         //yield return new WaitForSeconds(1);
        */

       
        AppOptions options = new AppOptions();
        options.DatabaseUrl = new System.Uri("https://virtual-saf-default-rtdb.firebaseio.com");
        //new System.Uri("https://virtual-saf-default-rtdb.firebaseio.com");
       // AppOptions.LoadFromJsonConfig(Application.streamingAssetsPath + "/" + file.name);
        FirebaseApp app = FirebaseApp.Create(options);
        //app.Options.
        //app.Options.DatabaseUrl.AbsoluteUri = "https://virtual-saf-default-rtdb.firebaseio.com";
        reference = FirebaseDatabase.GetInstance(app,"https://virtual-saf-default-rtdb.firebaseio.com").RootReference;
        //reference.Child("test").Child("" + ((int)Time.realtimeSinceStartup)).SetValueAsync(Time.realtimeSinceStartup);

        InitializeFirebase();

    }
    void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
        provider = PhoneAuthProvider.GetInstance(auth);
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
        

    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + JsonUtility.ToJson(user.UserId));

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       // reference.Child("test").Child(""+((int)Time.realtimeSinceStartup)).SetValueAsync(Time.realtimeSinceStartup);

    }
    public void Login()
    {
        InitializeFirebase();
        provider.VerifyPhoneNumber("+216"+ phoneNumber.text, 10000, null,
          verificationCompleted: (credential) => {
              Debug.Log("credential = "+ JsonUtility.ToJson(credential));
              // Auto-sms-retrieval or instant validation has succeeded (Android only).
              // There is no need to input the verification code.
              // `credential` can be used instead of calling GetCredential().
          },
          verificationFailed: (error) => {
              Debug.LogError(error);
      // The verification code was not sent.
      // `error` contains a human readable explanation of the problem.
  },
          codeSent: (id, token) => {
              Debug.Log(id + " token= " + JsonUtility.ToJson(token));
              verificationId = id;
      // Verification code was successfully sent via SMS.
      // `id` contains the verification id that will need to passed in with
      // the code from the user when calling GetCredential().
      // `token` can be used if the user requests the code be sent again, to
      // tie the two requests together.
          });
}
    public InputField verificationCode;
    public string verificationId;
    public void VerifyCode()
    {
        Credential credential =
        provider.GetCredential(verificationId, verificationCode.text);

        auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithCredentialAsync encountered an error: " +
                               task.Exception);
                return;
            }

            FirebaseUser newUser = task.Result;
            Debug.Log("User signed in successfully");
            // This should display the phone number.
            Debug.Log("Phone number: " + newUser.PhoneNumber);
            // The phone number providerID is 'phone'.
            Debug.Log("Phone provider ID: " + newUser.ProviderId);
        });

    }
    

}
