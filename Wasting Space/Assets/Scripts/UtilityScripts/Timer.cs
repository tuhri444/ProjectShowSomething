using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private float startTime = 300;
    private float currentTime;
    private TMP_Text timerText;

    private StopTheGame gameEnd;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TMP_Text>();
        gameEnd = FindObjectOfType<StopTheGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(startTime-currentTime <= 0)
        {
            OnDeath onDeath = FindObjectOfType<OnDeath>();
            if (onDeath != null)
            {
                Destroy(onDeath);
            }
        }
        else if(!gameEnd.Activated)
        {
            currentTime += Time.deltaTime;
            float elapsed = startTime - currentTime;
            timerText.text = FormatSeconds(elapsed);
        }
    }

    string FormatSeconds(float elapsed)
    {
        int d = (int)(elapsed * 100.0f);
        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;
        return String.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
