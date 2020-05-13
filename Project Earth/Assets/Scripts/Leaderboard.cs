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
    private Dictionary<string, int> leaderboardScores = new Dictionary<string, int>();
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

        //leaderboardScores.Add("Fynn", 400);

        //leaderboardScores.Add("Rowan", 100);

        //leaderboardScores.Add("Jason", 200);

        //leaderboardScores.Add("Arjen", 300);

        //leaderboardScores.Add("TheLegend27", 3000);

        //leaderboardScores.Clear();
        leaderboardScores = gameManager.loadScores();

        for (int i = 0; i < leaderboardScores.Count; i++)
        {
            Debug.Log("Names: " + PlayerPrefs.GetString("TopScorer" + i) + " Leaderboard score: " + leaderboardScores[PlayerPrefs.GetString("TopScorer" + i)]);
        }

        leaderboardScores.Add(gameManager.Name, gameManager.GetScore());
        SortDictionary();
        Debug.Log(leaderboardScores.Count);
        gameManager.saveScores(leaderboardScores);

        for (int i = 0; i < leaderboardScores.Count; i++)
        {
            ScoreSlot slot = leaderboardSlots[i].GetComponent<ScoreSlot>();
            slot.Name.text = leaderboardScores.Keys.ToList()[i];
            slot.Score.text = leaderboardScores.Values.ToList()[i] + "";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SortDictionary()
    {
        // Sorted by Value  
        Dictionary<string, int> outDict = new Dictionary<string, int>();
        var temp = from pair in leaderboardScores orderby pair.Value descending select pair;
        foreach (KeyValuePair<string, int> pair in temp)
        {
            outDict.Add(pair.Key, pair.Value);
        }
        leaderboardScores = outDict;
    }

}
