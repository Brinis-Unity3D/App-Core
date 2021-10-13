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
        return s.agents.Contains(UserManager.instance.user.email);
    }
}
