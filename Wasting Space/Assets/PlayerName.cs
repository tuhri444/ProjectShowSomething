using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerName : MonoBehaviour
{
    TMP_Text playerNameText;
    // Start is called before the first frame update
    void Start()
    {
        playerNameText = GetComponent<TMP_Text>();
        playerNameText.text = PlayerPrefs.GetString("CurrentPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
