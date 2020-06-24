using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FInalScore : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timer;

    [SerializeField]
    private TMP_Text score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //string timerScoreText = timer.text;
        string scoreText = score.text;

        //int timeScore;
        //int.TryParse(timerScoreText, out timeScore);
        //Debug.Log(timeScore);
        //int numScore;
        //int.TryParse(scoreText,out numScore);
        //Debug.Log(numScore);

        GetComponent<TMP_Text>().text = scoreText+  "";
    }
}
