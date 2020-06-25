using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class LoadScene : MonoBehaviour
{

    private List<KeyValuePair<string, int>> scorers = new List<KeyValuePair<string, int>>();
    private bool currentPlayer = false;
    private NoNoWarning nonoWarning;
    int sceneId;

    List<string> nonoNames = new List<string>() {
        "kut", "hoer", "slet", "piemel", "penis", "nigger", "fuck", "neger", "kanker", "tering", "tyfus", "cunt", "bitch",
        "dick", "cock", "vag", "kenker", "anal", "kuck", "poop", "sex", "sexy", "hoe", "rape", "kill", "murder", "hitler", "kok",
        "slaaf", "slave", "jood", "kech", "thot", "fag", "faggot", "shit", "homo", "pot", "weed", "drugs", "wiet", "dead",
        "lsd", "death", "chink", "nigga", "nibba", "chigga", "niggle", "porn", "porno", "hentai”, “oppai”, “rawrxd”, “arsch", "fotze",
        "anaal", "moord", "geil", "horny", "furry","niger","neeger","negeer","pimmel","vagina","pussy","slut","pick","pee","0","1",
        "2","3","4","5","6","7","8","9","@","corona","covid","dood","=","!","$","lijer","leijer","leier","hell","smegma","cum","sperm",
        "pauper","jizz","negro","kont","pis","pies","pik","mongol","balls","downy","wanker","kloot","downie","idiot","idioot","dumb",
        "bugger","blood","bleed","kak","choad","chode","keutel","shag","mof","heil","twat","pedo","drol","autist","retard","kreng",
        "hufter","banga","sanga","cancer","neuk","heks","fuk","arjen","fuc","berm","anus","bollox","boner","styve","stijve","tit",
        "tatas","boobs","tiet","borst","tepel","clit","poes","cunnie","breast","wank","recktum","rectum","rukken","hussy","whore","va j j",
        "vjay","fap","rukker","shiz","nazi","skank","rimjob","queef","fart","scheet","schijt","puto","puta","isis","pisda",
        "kooch","fuhrer","jerk","kuchka","kurva","putka","hui","erect","butt","suchka","suka","cabron","pishka","pussi","dildo"
    };
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame

    public void Load(int id)
    {
        nonoWarning = FindObjectOfType<NoNoWarning>();

        if(SceneManager.GetActiveScene().name.Equals("Start") && PlayerPrefs.GetString("RoadsterEnabled").Equals("true"))
        {
            SceneManager.LoadScene(2);
        }
        else if (SceneManager.GetActiveScene().name == "FlightTest")
        {
            PlayerSettings playerSettings = FindObjectOfType<PlayerSettings>();
            string name = GameObject.Find("NameInput").GetComponent<TMP_InputField>().text;
            name = name.Trim(' ');
            if (!nonoNames.Any(name.ToLower().Contains))
            {
                nonoWarning.Activate(false);
                PlayerPrefs.SetString("CurrentPlayer", name);
                PlayerPrefs.SetInt("CurrentScore",FindObjectOfType<FInalScore>().FinalScore);
                Debug.Log(name);
                Sheets.AddScoreEntry(FindObjectOfType<FInalScore>().FinalScore, name);
                Sheets.SortRequest();
                SceneManager.LoadScene(id);
            }
            else
            {
                nonoWarning.Activate(true);
            }
        }
        else
        {
            SceneManager.LoadScene(id);
        }

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
