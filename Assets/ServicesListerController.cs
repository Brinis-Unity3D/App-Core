using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicesListerController : MonoBehaviour
{
    // Start is called before the first frame update
    public ServiceConsumersListController consumersList;
    public Transform prefab;
    void  Start()
    {
       // yield return new WaitForSeconds(1);
        brinis.ListingManager.SyncTableFromDatabase<ServiceStation>(prefab);
        print("");
    }
    public void OpenServiceConumersList(ServiceStation s)
    {
        consumersList.service = s;
        consumersList.gameObject.SetActive(false);
        consumersList.GetComponent<EFE_PanelTransition>().DoTransitionIn();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
