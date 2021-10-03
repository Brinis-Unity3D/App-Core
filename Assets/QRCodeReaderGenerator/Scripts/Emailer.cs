//  Emailer.cs
//  http://www.mrventures.net/all-tutorials/sending-emails
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using static UnityEngine.UI.InputField;

public class Emailer : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI txtData;
    [SerializeField] UnityEngine.UI.Button btnSubmit;
    [SerializeField] bool sendDirect;

    const string kSenderEmailAddress = "brinis2017@gmail.com";
    const string kSenderPassword = "Messi007++";
    const string kReceiverEmailAddress = "brinis2019@gmail.com";

    // Method 2: Server request
    const string url = "https://coderboy6000.000webhostapp.com/emailer.php";

    void Start()
    {
        //SendAnEmail("test QR code");
        UnityEngine.Assertions.Assert.IsNotNull(txtData);
        UnityEngine.Assertions.Assert.IsNotNull(btnSubmit);
        btnSubmit.onClick.AddListener(delegate {
            if (sendDirect)
            {
                SendAnEmail(txtData.text);
            }
            else
            {
                SendServerRequestForEmail(txtData.text);
            }
        });
    }
    public static string StreamingAssetPathForWWW()
    {
        
        #if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
                return "file://" + Application.dataPath + "/StreamingAssets/";
        #endif
        #if UNITY_ANDROID
                return "file://" + Application.persistentDataPath+"/";
        #endif
        #if UNITY_IOS
                return "file://" + Application.dataPath + "/Raw/";
        #endif
                throw new System.NotImplementedException("Check the ifdefs above.");
    }
    // Method 1: Direct message
    public static void SendAnEmail(string message,byte[] fileBytes=null)
    {
        // Create mail
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(kSenderEmailAddress);
        mail.To.Add(kReceiverEmailAddress);
        mail.Subject = "Email Title";
        mail.Body = message;

        if (fileBytes != null)
        {

            string attachmentPath = Application.persistentDataPath + "/QRcode.png";

            if (!Directory.Exists(Application.persistentDataPath))
                Directory.CreateDirectory(Application.persistentDataPath);

                File.WriteAllBytes(attachmentPath, fileBytes);
            print("attachement path ) " + attachmentPath);
            Attachment inline = new Attachment(attachmentPath);
            inline.ContentDisposition.Inline = true;
            inline.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
            inline.ContentType.MediaType = "image/png";
            inline.ContentType.Name = Path.GetFileName(attachmentPath);

            mail.Attachments.Add(inline);
        }
        //mail.Attachments.Add(new Attachment(filePath));
        // Setup server 
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new NetworkCredential(
            kSenderEmailAddress, kSenderPassword) as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate,
            X509Chain chain, SslPolicyErrors sslPolicyErrors) {
                Debug.Log("Email success!");
                return true;
            };

        // Send mail to server, print results
        try
        {
            smtpServer.Send(mail);
        }
        catch (System.Exception e)
        {
            Debug.Log("Email error: " + e.Message);
        }
        finally
        {
            Debug.Log("Email sent!");
        }
    }

    // Method 2: Server request
    private void SendServerRequestForEmail(string message)
    {
        StartCoroutine(SendMailRequestToServer(message));
    }

    // Method 2: Server request
    static IEnumerator SendMailRequestToServer(string message)
    {
        // Setup form responses
        WWWForm form = new WWWForm();
        form.AddField("name", "It's me!");
        form.AddField("fromEmail", kSenderEmailAddress);
        form.AddField("toEmail", kReceiverEmailAddress);
        form.AddField("message", message);

        // Submit form to our server, then wait
        WWW www = new WWW(url, form);
        Debug.Log("Email sent!");

        yield return www;

        // Print results
        if (www.error == null)
        {
            Debug.Log("WWW Success!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}