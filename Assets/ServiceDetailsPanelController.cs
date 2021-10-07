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
        service = brinis.ListingManager.Load<ServiceStation>(service.id);
        service.currentLast = service.clientsListForToday.Count - 1;
        brinis.EasyCrudsManager.SetTextAutomaticly<ServiceStation>(transform, service);
        ShowPlayerIndexOrSubscribeButton();
    }
    void ShowPlayerIndexOrSubscribeButton()
    {
        if (!subscribeButton) return;
        if (!userIndex) return;

        foreach (Placement p in service.clientsListForToday)
        {
            if(p.relation.client== UserManager.instance.user.id)
            {
                subscribeButton.gameObject.SetActive(false);
                userIndex.transform.parent.gameObject.SetActive(true);
                userIndex.text = "" + service.clientsListForToday.IndexOf(p);
                return;
            }
        }
        subscribeButton.gameObject.SetActive(true);
        userIndex.transform.parent.gameObject.SetActive(false);
      

    }
    public void Subscribe()
    {
        Placement placement = new Placement();
        placement.relation.client = UserManager.instance.user.id;
        placement.relation.station = service.id;
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
