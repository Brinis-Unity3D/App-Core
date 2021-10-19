using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceDetailsPanelController : MonoBehaviour
{
    // Start is called before the first frame update
    public ServiceStation service = new ServiceStation();
    public GameObject subscribeButton;
    public TMPro.TextMeshProUGUI userIndex;
    void OnEnable()
    {
        UpdatePanel();
    }
    public void UpdatePanel()
    {
        try
        {
            service = brinis.ListingManager.Load<ServiceStation>(service.id);
            service.currentLast = service.clientsListForToday.Count;
            brinis.EasyCrudsManager.SetTextAutomaticly<ServiceStation>(transform, service);
            ShowPlayerIndexOrSubscribeButton();
        }catch(Exception e)
        {
            Debug.LogError("brinis log" + e.Message);
        }
    }
    void ShowPlayerIndexOrSubscribeButton()
    {
        if (!subscribeButton) return;
        if (!userIndex) return;
       
        foreach (Placement p in service.clientsListForToday)
        {
            if(p.relation.client== UserManager.instance.user.id)
            {
                if (!service.agents.Contains(UserManager.instance.user.email))
                    subscribeButton.gameObject.SetActive(false);

                userIndex.transform.parent.gameObject.SetActive(true);
                userIndex.text = "" + service.clientsListForToday.IndexOf(p)+1;

                if(p.relation.index!=0)
                userIndex.text = "" + p.relation.index;
                return;
            }
        }
       
       
            
          
            subscribeButton.gameObject.SetActive(true);
            if (!service.agents.Contains(UserManager.instance.user.email))
            userIndex.transform.parent.gameObject.SetActive(false);

      
      

    }
    public void Subscribe()
    {
        service = brinis.ListingManager.Load<ServiceStation>(service.id);
        Placement placement = new Placement();
        placement.relation.client = UserManager.instance.user.id;
        placement.relation.station = service.id;
        placement.relation.date = System.DateTime.UtcNow;
        placement.relation.index = service.currentLast + 1;
        UserManager.instance.user.history.Add(placement);
        UserManager.instance.SaveUser();
        service.clientsListHistory.Add(placement);
        service.clientsListForToday.Add(placement);
        brinis.ListingManager.Save<ServiceStation>(service);
        UpdatePanel();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
