using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardSlot : MonoBehaviour
{

    private float rank;
    private string name;
    private string score;

    private GameObject nameText;
    private GameObject rankText;

    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        rankText = transform.GetChild(0).gameObject;
        nameText = transform.GetChild(1).gameObject;
        scoreText = transform.GetChild(2).gameObject;

        nameText.GetComponent<TMP_Text>().text = name;
        rankText.GetComponent<TMP_Text>().text = rank + "";
        scoreText.GetComponent<TMP_Text>().text = score + "";
    }

    public void ChangeValues(float _rank, string _name, string _score)
    {
        nameText.GetComponent<TMP_Text>().text = _name;
        rankText.GetComponent<TMP_Text>().text = _rank + "";
        scoreText.GetComponent<TMP_Text>().text = _score + "";
    }


    public float Rank
    {
        get{ return rank; }
        set { rank = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Score
    {
        get { return score; }
        set { score = value; }
    }
}
