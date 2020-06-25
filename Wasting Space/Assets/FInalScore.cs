using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FInalScore : MonoBehaviour
{
    [SerializeField]
    private GetTime timer;

    [SerializeField]
    private Score score;

    private int finalScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        finalScore = (int)(timer.CurrentTime + score.NumScore);
        GetComponent<TMP_Text>().text = ((int)(timer.CurrentTime+score.NumScore))+  "";
    }

    public int FinalScore
    {
        get { return finalScore; }
    }

}
