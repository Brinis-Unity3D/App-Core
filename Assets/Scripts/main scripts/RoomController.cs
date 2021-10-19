using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using brinis;

public class RoomController : MonoBehaviour
{
    public Room info;
    public RoomChangeController gouvernantePanels, receptionPanel;
    // Start is called before the first frame update
  void OnEnable()
    {
        if (info == null) return;

        if(info.status==RoomStatus.NotReady)
            {
                GetComponent<Image>().color = Color.red;
            }
        if (info.status == RoomStatus.Preparing)
        {
            GetComponent<Image>().color = Color.yellow;
        }
        if (info.status == RoomStatus.Ready)
        {
            GetComponent<Image>().color = Color.green;
        }
    }
    public void OnCLick()
    {

            Debug.Log("OnCLick at " + info.id);
        /*  gouvernantePanels.gameObject.SetActive(false);
         receptionPanel.gameObject.SetActive(false);



        gouvernantePanels.gameObject.SetActive(ProfileManager.isForGouvernante);
        receptionPanel.gameObject.SetActive(!ProfileManager.isForGouvernante);*/
        gouvernantePanels.roomToModify = info;
        receptionPanel.roomToModify = info;
        if (ProfileManager.isForGouvernante)
        EasyCrudsManager.SetTextAutomaticly<Room>(gouvernantePanels.transform, info);
        else
        EasyCrudsManager.SetTextAutomaticly<Room>(receptionPanel.transform, info);
        


    }
}
