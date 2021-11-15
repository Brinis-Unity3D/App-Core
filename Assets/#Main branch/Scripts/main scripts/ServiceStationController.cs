using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceStationController : MonoBehaviour
{
    // Start is called before the first frame update
    public ServicesListerController serviceLister;
    public ServiceStation info;

   
    public void OnClicked()
    {
        serviceLister.OpenServiceConumersList(info);
    }
    public bool ShouldShow(ServiceStation s)
    {
        if (s == null) return false;
        if (s.agents == null) return false;
        if (UserManager.instance == null) return false;
        if (UserManager.instance.user == null) return false;
        if (string.IsNullOrWhiteSpace( UserManager.instance.user.email)) return false;
        return s.agents.Contains(UserManager.instance.user.email);
    }
}
