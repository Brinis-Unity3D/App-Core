using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceStationController : MonoBehaviour
{
    // Start is called before the first frame update
    public ServicesListerController serviceLister;
    public ServiceStation info;
    public bool isClient = false;
   
    public void OnClicked()
    {
        if(isClient==false)
        serviceLister.OpenServiceConumersList(info);
        else
        {
            serviceLister.OpenServiceDetails(info);
        }
    }
    public bool ShouldShow(ServiceStation s)
    {
      
        Debug.Log("should show called at " + name + "  about "+s.name);
        Debug.Log("before s ==null ");
        if (s == null) return false;
        Debug.Log("before agents ==null ");
        if (s.agents == null) return false;
        Debug.Log("before UserManager.instance == null");
        if (UserManager.instance == null) return false;
        Debug.Log("UserManager.instance.user == null");
        if (UserManager.instance.user == null) return false;
        Debug.Log("UserManager.instance.user.email == null");
        if (string.IsNullOrWhiteSpace( UserManager.instance.user.email)) return false;
        if (!isClient)
        {
            Debug.Log("before s.agents.Contains(UserManager.instance.user.email);  UserManager.instance.user == null "+ UserManager.instance.user.email+" at prefab "+name);
            return s.agents.Contains(UserManager.instance.user.email);
        }
        else
        {
            Debug.Log("before checking  at " + name + "  about " + s.name);
            foreach (Placement p in s.clientsListForToday)
            { 

                if (p.relation.client == UserManager.instance.user.id)
                if((System.DateTime.UtcNow- p.relation.date.Date).TotalHours<24)
                if (System.DateTime.UtcNow.Day == p.relation.date.Day)
                {
                    Debug.Log("approved  at " + name + "  about " + s.name);
                    return true;
                }
            }
            Debug.Log("refused at " + name + "  about " + s.name);
            return false;
        }
    }

}
