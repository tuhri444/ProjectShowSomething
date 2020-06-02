using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    //Serializable Fields
    [SerializeField]
    private PlayerSettings playerSettings;
    [SerializeField]
    private Healthbar healthBar;

    //Non-Serializable Fields
    private float health = 100;
    private MeshRenderer meshRenderer;
    private CapsuleCollider capsuleCollider;
    private ShipSettings shipSettings;
    private GameObject grabber;
    private GameObject hull;
    private GameObject booster;

    // Start is called before the first frame update
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        capsuleCollider = GetComponent<CapsuleCollider>();
        capsuleCollider.enabled = false;
        playerSettings = FindObjectOfType<PlayerSettings>();
        healthBar = FindObjectOfType<Healthbar>();

        try
        {
            string grabberName = PlayerPrefs.GetString("ActiveGrabber");
            string hullName = PlayerPrefs.GetString("ActiveHull");
            string boosterName = PlayerPrefs.GetString("ActiveBooster");
            GameObject grabberPref = Resources.Load("Parts/Grabbers/" + grabberName) as GameObject;
            GameObject hullPref = Resources.Load("Parts/Hulls/" + hullName) as GameObject;
            GameObject boosterPref = Resources.Load("Parts/Boosters/" + boosterName) as GameObject;
            grabber = Instantiate(grabberPref, transform.GetChild(0));
            hull = Instantiate(hullPref, transform.GetChild(1));
            booster = Instantiate(boosterPref, transform.GetChild(2));
        }
        catch (Exception e)
        {
            meshRenderer.enabled = true;
            capsuleCollider.enabled = true;
            Debug.Log(e.Message);
            Debug.Log("There where no parts selected");
        }
        health = healthBar.MaxHealth;
    }

    public void Update()
    {
        healthBar.Health = health;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int amount = 10)
    {
        health -= amount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RadarObject")
        {
            Debug.Log("Hit");
            Damage(10);
        }
    }

    public ShipSettings GetShipSettings
    {
        get { return shipSettings; }
    }

    public PlayerSettings Settings
    {
        get { return playerSettings; }
    }

    public GameObject Grabber { get => grabber; }
    public GameObject Hull { get => hull; }
    public GameObject Booster { get => booster; }
}
