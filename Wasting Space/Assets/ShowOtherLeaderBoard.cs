using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOtherLeaderBoard : MonoBehaviour
{
    private PopulateLeaderboard leaderboardManager;
    private int CurrentSlot;
    void Start()
    {
        leaderboardManager = FindObjectOfType<PopulateLeaderboard>();
    }
    public void OnClickUp()
    {
        if (CurrentSlot > 0)
            CurrentSlot--;
        CurrentSlot = Mathf.Clamp(CurrentSlot, 0, 10);
        leaderboardManager.ChangeScoresShown(CurrentSlot);
    }

    public void OnClickDown()
    {
        if (CurrentSlot < leaderboardManager.Scorelist.Count-5)
            CurrentSlot++;
        CurrentSlot = Mathf.Clamp(CurrentSlot, 0, 10);
        leaderboardManager.ChangeScoresShown(CurrentSlot);
    }
}
