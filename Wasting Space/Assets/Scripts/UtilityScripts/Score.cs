using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    PlayerSettings playerSettings;
    TMP_Text scoreText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSettings == null)
        {
            playerSettings = FindObjectOfType<PlayerSettings>();
        }
        scoreText.text = playerSettings.JunkCollected + "";
        score = (int)playerSettings.JunkCollected;
    }

    public int NumScore
    {
        get{return score;}
    }
}
