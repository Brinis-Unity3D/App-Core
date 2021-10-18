using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LanguageEnum
{
    English,
    French,
    Russe,
    Chinese
}
public class LanguageController : MonoBehaviour
{
    public LanguageEnum language;
    private void Awake()
    {
        LanguageSetController.allLanguageControllers.Add(this);
    }
    private void OnEnable()
    {
        
        DoIt();
    }
    public void DoIt()
    {
        if (!PlayerPrefs.HasKey(LanguageSetController.ChosenLanguageKey))
        {
            PlayerPrefs.SetInt(LanguageSetController.ChosenLanguageKey, (int)LanguageEnum.English);
        }
        gameObject.SetActive(language == (LanguageEnum)PlayerPrefs.GetInt(LanguageSetController.ChosenLanguageKey));
    }
}
