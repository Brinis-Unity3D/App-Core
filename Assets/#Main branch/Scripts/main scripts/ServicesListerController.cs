using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicesListerController : MonoBehaviour
{
    // Start is called before the first frame update
    public ServiceConsumersListController consumersList;
    public Transform prefab;
    private void OnEnable()
    {
        brinis.ListingManager.SyncTableFromDatabase<ServiceStation>(prefab);
       
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
