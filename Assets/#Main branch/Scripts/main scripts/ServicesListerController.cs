using brinis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicesListerController : MonoBehaviour
{
    // Start is called before the first frame update
    public ServiceConsumersListController consumersList;
    public ServiceDetailsPanelController serviceDetailsPanel;
    public Transform prefab;
    private void OnEnable()
    {
        //brinis.ListingManager.SyncTableFromDatabase<ServiceStation>(prefab);
        brinis.EasyCrudsManager.ShowAllFunction<ServiceStation>(prefab,ListingManager.LoadTable<ServiceStation>());


    }
    IEnumerator  Start()
    {
        yield return new WaitForSeconds(1);
        brinis.ListingManager.SyncTableFromDatabase<ServiceStation>(prefab);
   
    }
    public void OpenServiceConumersList(ServiceStation s)
    {
        consumersList.service = s;
        consumersList.ShowList();
        consumersList.GetComponent<EFE_PanelTransition>().DoTransitionIn();
    }
    public void OpenServiceDetails(ServiceStation s)
    {
        serviceDetailsPanel.service = s;
        serviceDetailsPanel.GetComponent<EFE_PanelTransition>().DoTransitionIn();
        serviceDetailsPanel.UpdatePanel();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
