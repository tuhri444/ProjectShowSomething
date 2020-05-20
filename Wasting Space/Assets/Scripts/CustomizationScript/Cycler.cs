using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycler : MonoBehaviour
{
    //Serializable Fields
    [SerializeField]
    private List<GameObject> selections;

    //Non-Serializable Fields
    private int activeSeleciton;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0;i<transform.childCount;i++)
        {
            selections.Add(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject go in selections)
        {
            go.SetActive(false);
        }

        selections[activeSeleciton].SetActive(true);
    }

    public void Left()
    {
        activeSeleciton--;
        if (activeSeleciton < 0)
        {
            activeSeleciton = selections.Count - 1;
        }
    }

    public void Right()
    {
        activeSeleciton++;
        if (activeSeleciton > selections.Count - 1)
        {
            activeSeleciton = 0;
        }
    }

    public GameObject Part
    {
        get { return selections[activeSeleciton]; }
    }
}
