using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSettings : MonoBehaviour
{
    public static ShipSettings Instance;
    //Serializable Fields
    [SerializeField]
    private GameObject[] parts = new GameObject[3];
    //Non-Serializable Fields


    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        LoadResources();
    }

    void LoadResources()
    {
        string grabberName = PlayerPrefs.GetString("ActiveGrabber");
        string hullName = PlayerPrefs.GetString("ActiveHull");
        string boosterName = PlayerPrefs.GetString("ActiveBooster");
        parts[0] = Resources.Load("Parts/Grabbers/" + grabberName) as GameObject;
        parts[1] = Resources.Load("Parts/Hulls/" + hullName) as GameObject;
        parts[2] = Resources.Load("Parts/Boosters/" + boosterName) as GameObject;
    }

    public  GameObject[] Parts
    {
        get { return parts; }
        set { parts = value; }
    }
}
