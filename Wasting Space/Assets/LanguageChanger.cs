using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageChanger : MonoBehaviour
{

    private void Start()
    {
        PlayerPrefs.SetString("Language","Dutch");
    }
    public void ChangeLanguage(string Language)
    {
        PlayerPrefs.SetString("Language", Language);
    }
}
