using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayJunkCollected : MonoBehaviour
{
    private Text text;
    private string textToWrite;
    private PlayerSettings settings;
    void Start()
    {
        text = GetComponent<Text>();
        settings = FindObjectOfType<PlayerSettings>();
    }

    // Update is called once per frame
    void Update()
    {
        textToWrite = "Junk Collected: " + settings.JunkCollected;
        text.text = textToWrite;
    }
}
