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
    [SerializeField]
    private bool CAR = false;
    //Non-Serializable Fields
    [SerializeField] private float health = 100;
    private MeshRenderer meshRenderer;
    private CapsuleCollider capsuleCollider;
    private ShipSettings shipSettings;
    private GameObject grabber;
    private GameObject hull;
    private GameObject booster;
    private bool healthSet;
    // Start is called before the first frame update
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        playerSettings = FindObjectOfType<PlayerSettings>();
        healthBar = FindObjectOfType<Healthbar>();
        if (!CAR)
        {
            meshRenderer.enabled = false;
            capsuleCollider.enabled = false;
            try
            {
                string grabberName = PlayerPrefs.GetString("ActiveGrabber");
                //Debug.Log(grabberName);
                string hullName = PlayerPrefs.GetString("ActiveHull");
                string boosterName = PlayerPrefs.GetString("ActiveBooster");
                GameObject grabberPref = Resources.Load("Parts/Grabbers/" + grabberName) as GameObject;
                //Debug.Log(grabberPref == null);
                GameObject hullPref = Resources.Load("Parts/Hulls/" + hullName) as GameObject;
                //Debug.Log(hullPref == null);
                GameObject boosterPref = Resources.Load("Parts/Boosters/" + boosterName) as GameObject;
                //Debug.Log(boosterPref == null);
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
        }
        else
        {
            meshRenderer.enabled = false;
            capsuleCollider.enabled = false;
        }
        healthBar.MaxHealth = FindObjectOfType<Hull>().Health;
    }

    public void Update()
    {
        if(healthBar == null) healthBar = FindObjectOfType<Healthbar>();
        else
        {
            if(!healthSet)
            {
                health = healthBar.MaxHealth;
                healthSet = true;
            }
            else
            {
                healthBar.Health = health;
                if (health <= 0)
                {
                    GetComponent<ShipMovement>().EnableMovement = false;
                    Destroy(GetComponent<OnDeath>());
                }
            }
        }
    }

    public void Damage(float amount = 10)
    {
        health -= amount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RadarObject")
        {
            Debug.Log("Hit");
            Vector3 directionOfImpact = (collision.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(directionOfImpact * 10, ForceMode.Force);
            Damage(10);
            GetComponent<Rigidbody>().AddExplosionForce(200,collision.contacts[0].point,10);
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
