using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeLang : MonoBehaviour
{
    [SerializeField]
    private string message;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("Language").Contains("Dutch"))
        {
            GetComponent<TMP_Text>().text = message;
        }
    }
}
