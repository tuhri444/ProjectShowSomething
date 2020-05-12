using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    GameManager gameManager;
    List<GameObject> stars = new List<GameObject>();
    public int starId = 0;
    bool activated;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Rating");
        stars = new List<GameObject>(temp);
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(activated)
        {
            GetComponent<Image>().color = new Color(255, 242, 0);
        }
        else
        {
            GetComponent<Image>().color = new Color(255, 255, 255);
        }
    }

    public void Click()
    {
        for (int i = 0; i < stars.Count; i++)
        {
            stars[i].GetComponent<Star>().activated = false;
        }
        if (!activated)
        {
            for (int i = 0; i < starId; i++)
            {

                stars[i].GetComponent<Star>().activated = true;
            }
        }
        gameManager.rating = starId;
    }


}
