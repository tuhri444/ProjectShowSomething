using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    updateScore scoreText;
    public int score;
    public string Name;

    //public List<string> TopScorers = new List<string>();
    public int rating;
    public string feedback;
    public int currentScoreListNum = 0;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        scoreText = GameObject.Find("score").GetComponent<updateScore>();
        //PlayerPrefs.DeleteAll();
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
        for(int i = 0;i<_highscores.Keys.Count;i++)
        {
            PlayerPrefs.SetString("TopScorer"+i, _highscores.Keys.ToList()[i]);
            Debug.Log("NameFromPrefs:" +PlayerPrefs.GetString("TopScorer"+i));
            Debug.Log("Name:"+_highscores.Keys.ToList()[i]);
            PlayerPrefs.SetInt(_highscores.Keys.ToList()[i], _highscores.Values.ToList()[i]);
        }
        currentScoreListNum = _highscores.Keys.Count;
        PlayerPrefs.Save();
    }

    public Dictionary<string, int> loadScores()
    {
        Dictionary<string, int> scores = new Dictionary<string, int>();
        int amount = 4;
        if(currentScoreListNum > 5)
        {
            amount = 4;
        }
        for (int i = 0; i < amount; i++)
        {
            string name = PlayerPrefs.GetString("TopScorer" + i);
            Debug.Log("LoadingName:"+name);
            scores.Add(name,PlayerPrefs.GetInt(name, -1));
        }
        return scores;
    }

    public void saveFeedback(string feeback)
    {
        PlayerPrefs.SetString(Name, feeback);
        PlayerPrefs.Save();
    }
}
