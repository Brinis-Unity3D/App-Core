using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceConsumersListController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform userPrefab;
    public Transform userFakePrefab;
    public ServiceStation service = new ServiceStation();
    void OnEnable()
    {
        if (service==null) return;
        Dictionary<string, UserInfo> allInfos = new Dictionary<string, UserInfo>();
        foreach(Placement p in service.clientsListForToday)
        {
            allInfos.Add(p.relation.client, brinis.ListingManager.Load<UserInfo>(p.relation.client));
        }
        
        brinis.ListingManager.SyncTableFromDatabase<UserInfo>(userFakePrefab);
        brinis.EasyCrudsManager.ShowAll<UserInfo>(userPrefab, allInfos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
