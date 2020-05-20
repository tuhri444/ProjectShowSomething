using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSettings : MonoBehaviour
{
    public static ShipSettings Instance;
    //Serializable Fields
    [SerializeField]
    private GameObject[] parts = new GameObject[2];
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

    public  GameObject[] Parts
    {
        get { return parts; }
        set { parts = value; }
    }
}
