using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CapacityBar : MonoBehaviour
{

    //Serializable Fields
    [SerializeField]
    private float freeSpace = 50;

    //Non-Serializable Fields
    private Slider slider;
    private PlayerSettings playerSettings;
    private Hull hull;


    void Start()
    {
        slider = GetComponent<Slider>();
        playerSettings = FindObjectOfType<PlayerSettings>();
        hull = FindObjectOfType<Hull>();
        freeSpace = hull.Capacity;
        slider.maxValue = hull.Capacity;

    }

    void Update()
    {
        slider.value = freeSpace - playerSettings.InternalJunkCollected;
    }

    public float Capacity
    {
        get { return freeSpace; }
        set { freeSpace = value; }
    }
}
