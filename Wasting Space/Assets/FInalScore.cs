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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = ((int)(timer.CurrentTime+score.NumScore))+  "";
    }
}
