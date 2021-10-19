using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System;

using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using Firebase;
using Firebase.Database;
using brinis;
public class ClientInsertController : MonoBehaviour
{
    

    [SerializeField] private InputField nom;
    [SerializeField] private InputField prenom;
    [SerializeField] private Text dateNaiss;
    [SerializeField] private InputField lieu;
    [SerializeField] private Dropdown nationalite;
    [SerializeField] private InputField profession;
    [SerializeField] private InputField domicile;
    [SerializeField] private InputField email;
    [SerializeField] private InputField tel;
    [SerializeField] private InputField venantDe;
    [SerializeField] private InputField allantA;
    [SerializeField] private Text entreLe;
    [SerializeField] private Text dateDep;
    [SerializeField] private Dropdown PassOrCIN;
    [SerializeField] private InputField num;
    [SerializeField] private Text delivreLe;
    [SerializeField] private InputField a;
    [SerializeField] private InputField par;
    [SerializeField] private InputField numChambre;

    [SerializeField] private List<InputField> inputs;
    
    [SerializeField] private GameObject submitBtn;
    

    private ClientInfo client;
    private Color defaultInputColor;
    DatabaseReference reference;
    public GameObject errorText;
    public GameObject NointernetText;
    public GameObject successText;
    //write in firebase

    //Check inputs
    private void Start()
    {
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://hotelmouradiclub.firebaseio.com/");
        
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    private void OnEnable()
    {
        Debug.Log("Im onEnable");
        
    }
    public bool CheckInputs()
    {
        Debug.Log("Im checkinputs");
        bool isEmpty = false;
        if (!dateNaiss.text.Contains("/"))
        {
            dateNaiss.color = Color.red;
            isEmpty = true;
        }
        if (!entreLe.text.Contains("/"))
        {
            entreLe.color = Color.red;
            isEmpty = true;
        }
        if (!dateDep.text.Contains("/"))
        {
            dateDep.color = Color.red;
            isEmpty = true;
        }
            foreach (InputField item in inputs)
        {
            if(item.text.Length <= 0)
            {
                defaultInputColor = item.placeholder.color;
                item.placeholder.color = Color.red;
                isEmpty = true;
            }
        }

        return isEmpty;
    }

    //Create And Add Client

    /*public void CreateClient()
    {    
        //Check if inputfields are empty

        if (CheckInputs())
        {
            return;
        } else
        {
            //Create Client
           
            client = new ClientInfo( nom.text,  prenom.text, dateNaiss.text,  lieu.text,  nationalite.text,  profession.text,  domicile.text, email.text,  tel.text,  venantDe.text,  allantA.text,  entreLe.text,  dateDep.text,  PassOrCIN.options[PassOrCIN.value].text,  num.text,  delivreLe.text,  a.text,  par.text,  numChambre.text);
            

        }
        
    }*/

    private void OnDisable()
    {
        Debug.Log("Im onDisEnable");
        foreach (InputField item in inputs)
        {
            item.placeholder.color = defaultInputColor;
            item.text = "";
            //resultText.color = Color.red;
            //resultText.text = "";
        }
    }

    public void SendMessage()
    {
        Debug.Log("Im sendmessage");
        MailMessage mail = new MailMessage();
        string path = Application.persistentDataPath + "  " +nom.text+".xls";
        Debug.Log(path);
        if (!File.Exists(path))
        {
            File.WriteAllText(path, nom.text + "  "+prenom.text);
        }
        string content = "<br/>";
        mail.IsBodyHtml = true;
        mail.From = new MailAddress("poutit@live.fr");
        mail.To.Add("poutit@live.fr");

        //mail.From = new MailAddress("online@elmouradi.com");
        //mail.To.Add("online@elmouradi.com");

        mail.Subject = "Check In Mr/Ms " + nom.text + "  "+prenom.text;
        mail.Body = "Bonjour,<br/> Ce ci est un mail envoyé via l'application Hotel El Mouradi Club Kantaoui.";

        //if (CheckInputs()||(!checkFormat(dateNaiss.text))|| (!checkFormat(dateDep.text))|| (!checkFormat(entreLe.text)))
        if (CheckInputs())
        {
            errorText.SetActive(true);
            return;
        }
        else
        {
            content += "<br/> <span style='color: rgba(255, 0, 0, 1); '>Nom: </span>" + nom.text;
            content += "<br/> <span style='color: rgba(255, 0, 0, 1); '>Prenom: </span>" + prenom.text;
            content += "<br/> <span style='color: rgba(255, 0, 0, 1); '>Date de naissance: </span>" + dateNaiss.text;
            content += "\t <span style='color: rgba(255, 0, 0, 1); '>Lieu: </span>" + lieu.text;
            content += "<br/> <span style='color: rgba(255, 0, 0, 1); '>Nationalité: </span>" + nationalite.options[nationalite.value].text;
            content += "\t <span style='color: rgba(255, 0, 0, 1); '>Profession: </span>" + profession.text;
            content += "<br/> <span style='color: rgba(255, 0, 0, 1); '>Domicile:</span> " + domicile.text;
            content += "<br/> <span style='color: rgba(255, 0, 0, 1); '>Email: </span>" + email.text;
            content += "<br/> <span style='color: rgba(255, 0, 0, 1); '>Telephone: </span>" + tel.text;
            content += "<br/> <span style='color: rgba(255, 0, 0, 1); '>Venant de: </span>" + venantDe.text;
            content += "\t <span style='color: rgba(255, 0, 0, 1); '>Allant a: </span>" + allantA.text;
            content += "<br/> <span style='color: rgba(255, 0, 0, 1); '>Entre le: </span>" + entreLe.text;
            content += "\t <span style='color: rgba(255, 0, 0, 1); '>Date de depart: </span>" + dateDep.text;
            content += "<br/> <span style='color: rgba(255, 0, 0, 1); '>Pssport/CIN: </span>" + PassOrCIN.options[PassOrCIN.value].text;
            content += "\t <span style='color: rgba(255, 0, 0, 1); '>Numero: </span>" + num.text;
            content += "<br/> <span style='color: rgba(255, 0, 0, 1); '>Delivre le: </span>" + delivreLe.text;
            content += "\t <span style='color: rgba(255, 0, 0, 1); '>A: </span>" + a.text;
            content += "\t <span style='color: rgba(255, 0, 0, 1); '>Par: </span>" + par.text;

            mail.Body += content;
            //content += "<br/> Num Chambre: " + numChambre.text;
            client = new ClientInfo();
            //nom.text, prenom.text, dateNaiss.text, lieu.text, nationalite.text, profession.text, domicile.text, email.text, tel.text, venantDe.text, allantA.text, entreLe.text, dateDep.text, PassOrCIN.options[PassOrCIN.value].text, num.text, delivreLe.text, a.text, par.text);
            client.nom = nom.text;
            client.prenom = prenom.text;
            client.dateNaiss = dateNaiss.text;
            client.lieu = lieu.text;
            client.nationalite = nationalite.options[nationalite.value].text;
            client.profession = profession.text;
            client.domicile = domicile.text;
            client.email = email.text;
            client.tel = tel.text;
            client.venantDe = venantDe.text;
            client.allantA = allantA.text;
            client.entreLe = entreLe.text;
            client.dateDep = dateDep.text;
            client.PassOrCIN = PassOrCIN.options[PassOrCIN.value].text;
            client.id = client.PassOrCIN;
            client.num = num.text;
            client.delivreLe = delivreLe.text;
            client.a = a.text;
            client.par = par.text;
            ListingManager.Save<ClientInfo>(client);
            Debug.Log(client.nom);
            //Add some to text to it
            string myTextbrute = content.Replace("<br/> <span style='color: rgba(255, 0, 0, 1); '>", "\n");
            myTextbrute = myTextbrute.Replace("\t <span style='color: rgba(255, 0, 0, 1); '>", "\n");
            myTextbrute = myTextbrute.Replace("</span>", "");
            File.AppendAllText(path, myTextbrute);
            
            Debug.Log(new Attachment(path));
            mail.Attachments.Add(new Attachment(path));
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                //myPanelError.SetActive(true);
                //Change the Text
                NointernetText.SetActive(true);  
                Debug.Log("Check internet connection");
            }


            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("hotelhotelo3d@gmail.com", "55770249") as ICredentialsByHost;
            smtpServer.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };
            smtpServer.Send(mail);
            Debug.Log("Client name" + client.nom);
            // StartCoroutine(EmptyEmailInputField());
            string json = JsonUtility.ToJson(client);
            Debug.Log("Json client is ready");
            Debug.Log("ref:= " + reference.Key);
            reference.Child("AllCustomers").Child(client.num).SetRawJsonValueAsync(json);
            Debug.Log("success and client was added");
            successText.SetActive(true);
            //submitBtn.GetComponent<Image>().sprite = checkedIm;
           // myPanel.SetActive(true);
            

        }
        PlayerPrefs.SetString("Name", nom.text +" "+prenom.text);
        PlayerPrefs.SetString("Room", num.text);
    }

    //check date format
    /*public Boolean checkFormat (string inputString)
    {
        DateTime theDate;
        
        if (DateTime.TryParse(inputString, out theDate))
        {
            String.Format("dd/MM/yyyy", theDate);
            return true;
        }
        else
        {
            Console.WriteLine("Invalid"); // <-- Control flow goes here
            return false;
        }
         
    }*/


}
