using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    //Serializable Fields
    [SerializeField]
    private float health = 100;
    [SerializeField]
    private float maxHealth = 100;

    //Non-Serializable Fields
    private Slider slider;
    

    void Start()
    {
        slider = GetComponent<Slider>();
        health = maxHealth;
    }

    void Update()
    {
        slider.value = health;
    }

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

}
