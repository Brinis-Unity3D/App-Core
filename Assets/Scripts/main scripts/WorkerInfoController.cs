using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using brinis;

public class WorkerInfoController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform layoutParent;
    public WorkerInfo info = new WorkerInfo();
    void Start()
    {
        EasyCrudsManager.SetTextAutomaticly<WorkerInfo>(transform,info);
        //ListingManager.Save<WorkerInfo>(info);
    }
 

   
}

