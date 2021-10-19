using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Close()
    {
        anim.SetTrigger("Close");
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
