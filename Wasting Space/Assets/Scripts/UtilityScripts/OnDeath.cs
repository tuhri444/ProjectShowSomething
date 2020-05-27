using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDeath : MonoBehaviour
{
    private List<KeyValuePair<string, int>> scorers = new List<KeyValuePair<string, int>>();

    private bool currentPlayer = false;
    private void OnDestroy()
    {
        Debug.Log("Yeay");
        PlayerSettings playerSettings = FindObjectOfType<PlayerSettings>();
        //PlayerPrefs.SetInt("CurrentPlayer", (int)playerSettings.JunkCollected);
        PlayerPrefs.SetInt(PlayerPrefs.GetString("CurrentPlayer"), (int)playerSettings.JunkCollected);

        LoadScores();

        QuickSort(scorers, 0, scorers.Count - 1);

        SaveScores();

        SceneManager.LoadScene(3);
    }

    private void Start()
    {
        //LoadScores();

        //SaveScores();
    }

    void LoadScores()
    {
        for (int i = 0; i < 100; i++)
        {
            string scorer = "Scorer" + i;
            try
            {
                Debug.Log(scorer);
                Debug.Log(PlayerPrefs.GetString(scorer));
                if (PlayerPrefs.GetString(scorer) == "" && currentPlayer == false)
                {
                    Debug.Log("UhOh");
                    string currentPlayerName = PlayerPrefs.GetString("CurrentPlayer");
                    PlayerPrefs.SetString(scorer, currentPlayerName + "," + PlayerPrefs.GetInt(currentPlayerName));
                    currentPlayer = true;
                }
                else
                {
                    break;
                }
            }
            catch (Exception e)
            {

            }
            string[] split = PlayerPrefs.GetString(scorer).Split(',');
            scorers.Add(new KeyValuePair<string, int>(split[0], int.Parse(split[1])));
        }
    }

    void SaveScores()
    {
        for (int i = 0; i < scorers.Count; i++)
        {
            string scorer = "Scorer" + i;
            PlayerPrefs.SetString(scorer, scorers[i].Key+","+scorers[i].Value);
        }
    }

    //O(nlogn) 
    public static void QuickSort(List<KeyValuePair<string, int>> array, int init, int end)
    {
        if (init < end)
        {
            int pivot = Partition(array, init, end);
            QuickSort(array, init, pivot - 1);
            QuickSort(array, pivot + 1, end);
        }
    }
    //O(n)
    private static int Partition(List<KeyValuePair<string,int>> array, int init, int end)
    {
        int last = array[end].Value;
        int i = init - 1;
        for (int j = init; j < end; j++)
        {
            if (array[j].Value <= last)
            {
                i++;
                Exchange(array, i, j);
            }
        }
        Exchange(array, i + 1, end);
        return i + 1;
    }
    private static void Exchange(List<KeyValuePair<string,int>> array, int i, int j)
    {
        KeyValuePair<string,int> temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
