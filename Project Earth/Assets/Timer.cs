using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    float waitTime = 5;
    public float fadeTime = 1.0f;
    float startTime = 0;
    float newAlpha = 0;
    bool canStartFade = false;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //Make the text move upwards
        //transform.Translate(0, Time.deltaTime * 1.0f, 0);

        //Compute and set the alpha value
        if (Time.time - startTime > waitTime && !canStartFade)
        {
            startTime = Time.time;
            canStartFade = true;
        }
        if(canStartFade)
        {
            newAlpha = 1.0f - (Time.time - startTime) / fadeTime;
            GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, newAlpha);

            //If alpha has decreased to zero, destroy this game object
            if (newAlpha <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
