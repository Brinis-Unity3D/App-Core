using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class OnEnableDo : MonoBehaviour
{
    public UnityEvent onStart,OnEnableEvent,OnDisableEvent,onUpdate;
    // Start is called before the first frame update
    void Start()
    {
        onStart.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        onUpdate.Invoke();
    }
    private void OnEnable()
    {
        OnEnableEvent.Invoke();
    }
    private void OnDisable()
    {
        OnDisableEvent.Invoke();
    }
}
