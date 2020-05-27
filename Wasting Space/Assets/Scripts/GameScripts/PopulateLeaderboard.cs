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
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<5;i++)
        {
            GameObject temp = Instantiate(leaderboardSlotPrefab, transform);
            leaderboardSlots.Add(temp);
        }
        for(int i = 0;i<leaderboardSlots.Count;i++)
        {
            if (PlayerPrefs.GetString("Scorer" + i) == "") return;
            string topScorer = PlayerPrefs.GetString("Scorer" + i);
            string[] split = topScorer.Split(',');
            string name = split[0];
            string scoreStr = split[1];

            leaderboardSlots[i].GetComponent<LeaderboardSlot>().Rank = i + 1;
            leaderboardSlots[i].GetComponent<LeaderboardSlot>().Name = name;
            leaderboardSlots[i].GetComponent<LeaderboardSlot>().Score = scoreStr;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
