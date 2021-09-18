using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactButton : MonoBehaviour
{
    public void CallMe()
    {
        Application.OpenURL("tel://+21673246011");
  
    }
    public void emailMe()
    {
        string to = "info.clubkantaoui@elmouradi.com";
        string subject = " ";
        string body = " ";
        Application.OpenURL("mailto:" + to + "?subject=" + subject + "&body=" + body);
    }
    public void map()
    {
        Application.OpenURL("https://www.google.com/maps/place/El+Mouradi+Club+Kantaoui/@35.9070273,10.5806923,17z/data=!3m1!4b1!4m8!3m7!1s0x12fd89a3a6d5091f:0x72ebacd66b583b37!5m2!4m1!1i2!8m2!3d35.907023!4d10.582881?hl=fr-FR");
    }
    public void web()
    {
        Application.OpenURL("https://www.elmouradi.com:444/cr2.resa/ui/aba/hotel-descriptif-El%20Mouradi%20Club%20Kantaoui-Sousse-Tunisie-713-869-1-1-showdate0.aspx");
    }
    
}
