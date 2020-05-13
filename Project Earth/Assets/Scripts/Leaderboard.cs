using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public GameObject leaderboardSlotPrefab;
    public GameManager gameManager;
    private List<GameObject> leaderboardSlots;
    private Dictionary<string,int> leaderboardScores = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        leaderboardSlots = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject slot = Instantiate(leaderboardSlotPrefab, transform);
            leaderboardSlots.Add(slot);
        }

        leaderboardScores.Add("Fynn", 400);
        gameManager.names.Add("Fynn");

        leaderboardScores.Add("Rowan", 100);
        gameManager.names.Add("Rowan");

        leaderboardScores.Add("Jason", 200);
        gameManager.names.Add("Jason");

        leaderboardScores.Add("Arjen", 300);
        gameManager.names.Add("Arjen");

        SortDictionary(leaderboardScores);

        gameManager.saveScores(leaderboardScores);

        leaderboardScores.Clear();
        leaderboardScores = gameManager.loadScores();

        for (int i = 0; i < leaderboardScores.Count; i++)
        {
            Debug.Log("Names: "+gameManager.names[i]+" Leaderboard score: " + leaderboardScores[gameManager.names[i]]);
        }

        gameManager.names.Add(gameManager.Name);
        leaderboardScores.Add(gameManager.Name, gameManager.GetScore());
        gameManager.saveScores(leaderboardScores);

        for (int i = 0; i < leaderboardScores.Count; i++)
        {
            ScoreSlot slot = leaderboardSlots[i].GetComponent<ScoreSlot>();
            slot.Name.text = gameManager.names[i];
            slot.Score.text = leaderboardScores[gameManager.names[i]] + "";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SortDictionary(Dictionary<string,int> scores)
    {
        // Sorted by Value  

        Console.WriteLine("Sorted by Value");
        Console.WriteLine("============="); 
        leaderboardScores.Clear();
        foreach (KeyValuePair<string, int> score in scores.OrderBy(key => key.Value))
        {
            leaderboardScores.Add(score.Key,score.Value);
        }
    }

}
