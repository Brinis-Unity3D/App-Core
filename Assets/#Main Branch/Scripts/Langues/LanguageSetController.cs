using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSetController : MonoBehaviour
{
    public static string ChosenLanguageKey = "languageChosen";
    public static List<LanguageController> allLanguageControllers = new List<LanguageController>();
    public Dropdown changeLanguage;
    public void ChooseLanguage(int languageChosen)
    {   if(languageChosen>10)
        {
            languageChosen = changeLanguage.value;
        }
        PlayerPrefs.SetInt(ChosenLanguageKey,languageChosen);
        //FirebaseNotificationController.instance.UnsubscribeToAllAndSubscribeToNew((LanguageEnum)languageChosen);
        foreach (LanguageController c in allLanguageControllers)
        {
            if(c!=null)
            {
                c.DoIt();
            }
        }
       /* if(GetComponent<LanguageDropDownUpdater>())
        {
            GetComponent<LanguageDropDownUpdater>().ChangeLanguage(languageChosen);
        }*/
    }
}
