using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    updateScore scoreText;
    public int score;
    public string Name;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        scoreText = GameObject.Find("score").GetComponent<updateScore>();
    }

    void Update()
    {
        score = scoreText.Score;
    }

    public int GetScore()
    {
        return score;
    }
}
