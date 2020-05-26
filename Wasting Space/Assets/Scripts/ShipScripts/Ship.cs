using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    //Serializable Fields
    [SerializeField]
    private PlayerSettings playerSettings;

    //Non-Serializable Fields
    private float health;
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

        try
        {
            string grabberName = PlayerPrefs.GetString("ActiveGrabber");
            string hullName = PlayerPrefs.GetString("ActiveHull");
            string boosterName = PlayerPrefs.GetString("ActiveBooster");
            grabber = Resources.Load("Parts/Grabbers/" + grabberName) as GameObject;
            hull = Resources.Load("Parts/Hulls/" + hullName) as GameObject;
            booster = Resources.Load("Parts/Boosters/" + boosterName) as GameObject;
            Instantiate(grabber, transform.GetChild(0));
            Instantiate(hull, transform.GetChild(1));
            Instantiate(booster, transform.GetChild(2));
        }
        catch (Exception e)
        {
            meshRenderer.enabled = true;
            capsuleCollider.enabled = true;
            Debug.Log(e.Message);
            Debug.Log(grabber != null);
            Debug.Log(hull != null);
            Debug.Log(booster != null);
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
}
