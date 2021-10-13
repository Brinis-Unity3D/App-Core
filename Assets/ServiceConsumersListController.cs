using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServiceConsumersListController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform userPrefab;
    public ServiceStation service = new ServiceStation();
    public Button nextButton;
    public ServiceDetailsPanelController serviceDetailsPanel;
    
    public void ShowList()
    {
        if (service == null) return;
        UpdatePanel();
        Dictionary<string, Client> allInfos = new Dictionary<string, Client>();
        foreach (Placement p in service.clientsListForToday)
        {

            if (!allInfos.ContainsKey("C"+p.relation.client))
            {
                Client c = brinis.ListingManager.Load<Client>(p.relation.client);
                if (p.relation.index != 0)
                    c.index = p.relation.index;
                else
                    c.index = service.clientsListForToday.IndexOf(p) + 1;
                //brinis.ListingManager.Save<Client>(c);
                allInfos.Add("C"+c.id,c);
            }

        }
        brinis.EasyCrudsManager.ShowAllFunction<Client>(userPrefab, allInfos);
        
    }
    public void UpdatePanel()
    {
        service = brinis.ListingManager.Load<ServiceStation>(service.id);
        CheckListOfHistoryForToday();
        service.currentLast = service.clientsListForToday.Count;
        if (service.currentIndex >= service.currentLast) { nextButton.interactable = false; service.currentIndex = service.currentLast; }
        brinis.EasyCrudsManager.SetTextAutomaticly<ServiceStation>(transform, service);
        brinis.ListingManager.Save<ServiceStation>(service);

    }

    public void Next()
    {
        service = brinis.ListingManager.Load<ServiceStation>(service.id);
        CheckListOfHistoryForToday();
        service.currentIndex++;
        UpdatePanel();
        NotifyClient(service.currentIndex + 3);
        NotifyClient(service.currentIndex + 2);
        NotifyClient(service.currentIndex + 1);
        NotifyClient(service.currentIndex);
    }
    List<Placement> listToRemoveForToday = new List<Placement>();
    public void CheckListOfHistoryForToday()
    {
        foreach(Placement p in service.clientsListForToday)
        {
            if ((p.relation.date.Year != System.DateTime.UtcNow.Year))      if(!listToRemoveForToday.Contains(p)) listToRemoveForToday.Add(p) ;
            if ((p.relation.date.Month != System.DateTime.UtcNow.Month))    if (!listToRemoveForToday.Contains(p)) listToRemoveForToday.Add(p);
            if ((p.relation.date.Day != System.DateTime.UtcNow.Day))        if (!listToRemoveForToday.Contains(p)) listToRemoveForToday.Add(p);
            //if (p.relation.date.Hour<5)                                     if (!listToRemoveForToday.Contains(p)) listToRemoveForToday.Add(p);
        }
        foreach(Placement p in listToRemoveForToday)
        {
            service.clientsListForToday.Remove(p);
        }
    }
    void NotifyClient(int index)
    {
        StartCoroutine(NotifyClientAsync(index));
    }
    IEnumerator NotifyClientAsync(int index)
    {
        yield return null;
        if (service.clientsListForToday.Count >= index)
        {
            NotifInfo notif = new NotifInfo();
            string clientID = service.clientsListForToday[index].relation.client;
            notif.title = service.name + " window " + service.windowNumber;
            notif.body = "There is only " + (index - service.currentIndex) + " persons before you at " + service.name + " window " + service.windowNumber;
            //NotificationEmetter.instance.SendMessageToTopic("/topics/" + clientID, notif);
            Client client = brinis.ListingManager.Load<Client>(clientID);
            Emailer.SendAnEmail(client.email, notif.body, notif.title);
        }
    }
  
   public void ShowAsClient()
    {
        serviceDetailsPanel.service = service;
        serviceDetailsPanel.UpdatePanel();
        serviceDetailsPanel.GetComponent<EFE_PanelTransition>().DoTransitionIn();
    }
        // Update is called once per frame
    void Update()
    {
        
    }
}
