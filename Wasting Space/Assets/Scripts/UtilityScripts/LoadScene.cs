using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadScene : MonoBehaviour
{

    private List<KeyValuePair<string, int>> scorers = new List<KeyValuePair<string, int>>();
    private bool currentPlayer = false;
    int sceneId;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    public void Load(int id)
    {
        if (SceneManager.GetActiveScene().name == "FlightTest")
        {
            PlayerSettings playerSettings = FindObjectOfType<PlayerSettings>();
            string name = GameObject.Find("NameInput").GetComponent<TMP_InputField>().text;
            Debug.Log(name);
            PlayerPrefs.SetString("CurrentPlayer", name);
            Debug.Log("CurrentPlayer Name:"+PlayerPrefs.GetString("CurrentPlayer"));
            PlayerPrefs.SetInt(name, (int)playerSettings.JunkCollected);

            LoadScores();

            QuickSort(scorers, 0, scorers.Count - 1);

            SaveScores();
        }

        SceneManager.LoadScene(id);


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
                    Debug.Log("Empty Slot, filling in now");
                    string currentPlayerName = PlayerPrefs.GetString("CurrentPlayer");
                    PlayerPrefs.SetString(scorer, currentPlayerName + "," + PlayerPrefs.GetInt(currentPlayerName));
                    currentPlayer = true;
                }
                else if(currentPlayer == true)
                {
                    break;
                }
            }
            catch (Exception e)
            {
                Debug.Log("Log this");
                Debug.Log(e.Message);
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
            PlayerPrefs.SetString(scorer, scorers[i].Key + "," + scorers[i].Value);
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
    private static int Partition(List<KeyValuePair<string, int>> array, int init, int end)
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
    private static void Exchange(List<KeyValuePair<string, int>> array, int i, int j)
    {
        KeyValuePair<string, int> temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
