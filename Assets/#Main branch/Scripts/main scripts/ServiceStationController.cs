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
        if (s == null) return false;
        if (s.agents == null) return false;
        if (UserManager.instance == null) return false;
        if (UserManager.instance.user == null) return false;
        if (string.IsNullOrWhiteSpace( UserManager.instance.user.email)) return false;
        if (isClient == false)
        {
            return s.agents.Contains(UserManager.instance.user.email);
        }
        else
        {
            Debug.Log("checking  at " + name + "  about " + s.name);
            foreach (Placement p in s.clientsListForToday)
            {
                if (p.relation.client == UserManager.instance.user.id)
                    if (System.DateTime.Now.Year == p.relation.date.Year)
                        if (System.DateTime.Now.Month == p.relation.date.Month)
                            if (System.DateTime.Now.Day == p.relation.date.Day)
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
