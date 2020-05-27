using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CapacityBar : MonoBehaviour
{

    //Serializable Fields
    [SerializeField]
    private int freeSpace = 50;
    [SerializeField]
    private int maxCapacity = 50;

    //Non-Serializable Fields
    private Slider slider;
    private PlayerSettings playerSettings;


    void Start()
    {
        slider = GetComponent<Slider>();
        playerSettings = FindObjectOfType<PlayerSettings>();
    }

    void Update()
    {
        slider.value = freeSpace-playerSettings.JunkCollected;
    }

    public int Capacity
    {
        get { return freeSpace; }
        set { freeSpace = value; }
    }
}
