using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    //Serializable Fields
    [SerializeField]
    private float health = 150;
    [SerializeField]
    private float maxHealth = 150;

    //Non-Serializable Fields
    private Image image;
    [SerializeField] private Animator icon;
    [SerializeField] private Animator bar;

    void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        health = maxHealth;
    }

    void Update()
    {
        image.fillAmount = health / maxHealth;
    }

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public void Pulse()
    {
        icon.SetTrigger("Pulse");
        bar.SetTrigger("Pulse");
    }

}
