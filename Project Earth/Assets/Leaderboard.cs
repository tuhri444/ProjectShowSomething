using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public GameObject leaderboardSlotPrefab;
    public GameManager gameManager;
    private List<GameObject> leaderboardSlots;
    private Dictionary<int, string> leaderboardScores = new Dictionary<int, string>();
    List<int> scores = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        leaderboardSlots = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject slot = Instantiate(leaderboardSlotPrefab, transform);
            leaderboardSlots.Add(slot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager == null)
        {
            try
            {
                gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
                scores.Add(gameManager.GetScore());
                sort(scores);
                for (int index = 0; index < scores.Count; index++)
                {
                    leaderboardScores.Add(scores[index], gameManager.Name);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return;
            }
            int i = 0;
            foreach (int score in scores)
            {
                Debug.Log(score);
                ScoreSlot slot = leaderboardSlots[i].GetComponent<ScoreSlot>();
                Debug.Log(slot == null);
                slot.Name.text = leaderboardScores[score];
                slot.Score.text = score + "";
                i++;
            }

        }
       
    }

    void sort(List<int> arr)
    {
        int n = arr.Count;

        // One by one move boundary of unsorted subarray 
        for (int i = 0; i < n - 1; i++)
        {
            // Find the minimum element in unsorted array 
            int min_idx = i;
            for (int j = i + 1; j < n; j++)
                if (arr[j] < arr[min_idx])
                    min_idx = j;

            // Swap the found minimum element with the first 
            // element 
            int temp = arr[min_idx];
            arr[min_idx] = arr[i];
            arr[i] = temp;
        }
        
    }
}
