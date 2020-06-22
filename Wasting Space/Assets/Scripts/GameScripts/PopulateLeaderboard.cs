using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopulateLeaderboard : MonoBehaviour
{
    //Serializable Fields
    [SerializeField]
    private GameObject leaderboardSlotPrefab;

    //Non-Serializable Fields
    private List<GameObject> leaderboardSlots = new List<GameObject>();

    public List<ScoreboardObject> Scorelist { get; private set; } = new List<ScoreboardObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<5;i++)
        {
            GameObject temp = Instantiate(leaderboardSlotPrefab, transform);
            leaderboardSlots.Add(temp);
        }
        Scorelist = Sheets.GetScores();
        for(int i = 0;i<leaderboardSlots.Count;i++)
        {
            leaderboardSlots[i].GetComponent<LeaderboardSlot>().Rank = i + 1;
            leaderboardSlots[i].GetComponent<LeaderboardSlot>().Name = Scorelist[i].name.ToString();
            leaderboardSlots[i].GetComponent<LeaderboardSlot>().Score = Scorelist[i].score.ToString();
        }
        GameObject.Find("PlayerPlace").GetComponent<TMP_Text>().text = ""+PlayerPrefs.GetInt("PlayerPlace");
    }


    public void ChangeScoresShown(int startValue)
    {
        for (int i = 0; i < leaderboardSlots.Count; i++)
        {
            float rank = startValue + i + 1;
            string name = Scorelist[startValue + i].name.ToString();
            string score = Scorelist[startValue + i].score.ToString();

            leaderboardSlots[i].GetComponent<LeaderboardSlot>().ChangeValues(rank, name, score);
        }
    }
}
