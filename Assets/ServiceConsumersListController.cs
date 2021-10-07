using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceConsumersListController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform userPrefab;
    public ServiceStation service = new ServiceStation();
    void OnEnable()
    {
        if (service==null) return;
        Dictionary<string, Client> allInfos = new Dictionary<string, Client>();
        foreach(Placement p in service.clientsListForToday)
        {
            if(!allInfos.ContainsKey(p.relation.client))
            allInfos.Add(p.relation.client, brinis.ListingManager.Load<Client>(p.relation.client));
        }
        
        
        brinis.EasyCrudsManager.ShowAll<Client>(userPrefab, allInfos);
        UpdatePanel();
    }
    public void Next()
    {
        service = brinis.ListingManager.Load<ServiceStation>(service.id);
        service.currentIndex++;
        brinis.ListingManager.Save<ServiceStation>(service);
        UpdatePanel();
    }
    public void UpdatePanel()
    {
        service = brinis.ListingManager.Load<ServiceStation>(service.id);
        service.currentLast = service.clientsListForToday.Count - 1;
        brinis.EasyCrudsManager.SetTextAutomaticly<ServiceStation>(transform, service);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
