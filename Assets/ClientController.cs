using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientController : MonoBehaviour
{
    // Start is called before the first frame update
    public Client info;
    public static ServiceConsumersListController serviceListConsumer;
    public Text indexText;
    void Start()
    {
        if (!serviceListConsumer) serviceListConsumer = FindObjectOfType<ServiceConsumersListController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
      /*  foreach (Placement p in serviceListConsumer.service.clientsListForToday)
        {
                 if (p.relation.index != 0)
                    info.index = p.relation.index;
                else
                    info.index = serviceListConsumer.service.clientsListForToday.IndexOf(p) + 1;
              
        }
        indexText.text ="" +info.index;
      */

    }
 
    
    public bool ShouldShow(Client c)
    {
        
        foreach(Placement p in serviceListConsumer.service.clientsListForToday)
        {
            if (p.relation.client == c.id) return true;
        }
        return false;
    }
}
