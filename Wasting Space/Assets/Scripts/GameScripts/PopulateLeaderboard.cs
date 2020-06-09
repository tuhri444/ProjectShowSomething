using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateLeaderboard : MonoBehaviour
{
    //Serializable Fields
    [SerializeField]
    private GameObject leaderboardSlotPrefab;

    //Non-Serializable Fields
    private List<GameObject> leaderboardSlots = new List<GameObject>();
    private List<ScoreboardObject> scorelist = new List<ScoreboardObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<5;i++)
        {
            GameObject temp = Instantiate(leaderboardSlotPrefab, transform);
            leaderboardSlots.Add(temp);
        }
        scorelist = Sheets.GetScores();
        for(int i = 0;i<leaderboardSlots.Count;i++)
        {
            leaderboardSlots[i].GetComponent<LeaderboardSlot>().Rank = i + 1;
            leaderboardSlots[i].GetComponent<LeaderboardSlot>().Name = scorelist[i].name.ToString();
            leaderboardSlots[i].GetComponent<LeaderboardSlot>().Score = scorelist[i].score.ToString();
        }

    }
}
