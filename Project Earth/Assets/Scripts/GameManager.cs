using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    updateScore scoreText;
    public int score;
    public string Name;

    Dictionary<string,int> highscores;
    public List<string> names = new List<string>();
    public int rating;
    public string feedback;
    void Awake()
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
        Debug.Log(score);
        return score;
    }

    public void saveScores(Dictionary<string, int> _highscores)
    {
        foreach (string names in _highscores.Keys)
        {
            PlayerPrefs.SetInt(names, _highscores[names]);
        }
        PlayerPrefs.Save();
    }

    public Dictionary<string, int> loadScores()
    {
        Dictionary<string, int> scores = new Dictionary<string, int>();
        int amount = names.Count;
        if (amount > 5)
        {
            amount = 5;
        }
        for (int i = 0; i < amount; i++)
        {
            scores.Add(names[i],PlayerPrefs.GetInt(names[i], 0));
        }
        return scores;
    }

    public void saveFeedback(string feeback)
    {
        PlayerPrefs.SetString(name, feeback);
        PlayerPrefs.Save();
    }
}
