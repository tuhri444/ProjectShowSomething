using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateLeaderboard : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> leaderboardSlots = new List<GameObject>();

    [SerializeField]
    private GameObject LeaderboardSlotPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<5;i++)
        {
            GameObject temp = Instantiate(LeaderboardSlotPrefab, transform);
            string topScorer = PlayerPrefs.GetString("TopScorer" + i);
            string[] split = topScorer.Split(',');
            string name = split[0];
            string scoreStr = split[0];
            int score = int.Parse(scoreStr);
            temp.GetComponent<LeaderboardSlot>().Rank = i+1;
            temp.GetComponent<LeaderboardSlot>().Name = name;
            temp.GetComponent<LeaderboardSlot>().Score = score;
            leaderboardSlots.Add(temp);
        }

        foreach(GameObject go in leaderboardSlots)
        {
            //go.
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
