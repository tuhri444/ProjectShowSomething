using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetTime : MonoBehaviour
{
    Timer timer;
    TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer == null)
        {
            timer = FindObjectOfType<Timer>();
        }
        timerText.text = timer.CurrentTime+"";
    }
}
