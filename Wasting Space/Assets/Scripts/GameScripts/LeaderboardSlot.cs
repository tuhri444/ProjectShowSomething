using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardSlot : MonoBehaviour
{

    private float rank;
    private string name;
    private int score;

    private GameObject nameText;
    private GameObject rankText;
    private GameObject scoreText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.GetComponent<TMP_Text>().text = name;
        rankText.GetComponent <TMP_Text>().text = rank + "";
        scoreText.GetComponent<TMP_Text>().text = score + "";
    }

    // Update is called once per frame
    void Update()
    {

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

    public int Score
    {
        get { return score; }
        set { score = value; }
    }
}
