using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public GameObject leaderboardSlotPrefab;
    public GameManager gameManager;
    private List<GameObject> leaderboardSlots;
    private Dictionary<string,int> leaderboardScores = new Dictionary<string, int>();
    private List<string> names = new List<string>();
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
                if (gameManager == null) return;
                leaderboardScores = gameManager.loadScores();
                for (int index = 0; index < scores.Count; index++)
                {
                    leaderboardScores.Add(gameManager.names[index], leaderboardScores[gameManager.names[index]]);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return;
            }
            for (int i = 0;i<leaderboardScores.Count;i++)
            {
                ScoreSlot slot = leaderboardSlots[i].GetComponent<ScoreSlot>();
                slot.Name.text = gameManager.names[i];
                slot.Score.text = leaderboardScores[gameManager.names[i]] + "";
                i++;
            }
            gameManager.saveScores(leaderboardScores);

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
