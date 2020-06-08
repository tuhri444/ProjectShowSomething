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
            Sheets.ConnectToGoogle();
            PlayerSettings playerSettings = FindObjectOfType<PlayerSettings>();
            string name = GameObject.Find("NameInput").GetComponent<TMP_InputField>().text;
            Debug.Log(name);
            Sheets.AddScoreEntry((int)playerSettings.JunkCollected, name);
            Sheets.SortRequest();
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
                else if (currentPlayer == true)
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
            PlayerPrefs.DeleteKey(scorer);
            PlayerPrefs.SetString(scorer, scorers[i].Key + "," + scorers[i].Value);
        }
    }
}
