using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileController : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TextMeshProUGUI nameLastName;
    public Client user;
    void Start()
    {
        
    }
    public void Show(Client client=null)
    {
        if (client == null)
            user = UserManager.instance.user;
        else
            user = client;
        brinis.EasyCrudsManager.SetTextAutomaticly<Client>(transform,user);
        nameLastName.text = user.name + " " + user.lastName;
    }

   public void ShowConnectedUser()
    {
        
        user = UserManager.instance.user;
        brinis.EasyCrudsManager.SetTextAutomaticly<Client>(transform, user);
        nameLastName.text = user.name + " " + user.lastName;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
