using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubmitData : MonoBehaviour
{
    GameManager gameManager;
    Text feedBack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        feedBack = GameObject.Find("InputText").GetComponent<Text>();
    }

    public void Click()
    {
        gameManager.saveFeedback("Rating:"+gameManager.rating +", Feedback:"+feedBack.text);
        Destroy(gameManager.gameObject);
        SceneManager.LoadScene(0);
    }
}
