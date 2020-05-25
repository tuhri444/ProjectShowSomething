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
    private GameObject[] shipParts;
    private MeshRenderer meshRenderer;
    private CapsuleCollider capsuleCollider;
    private ShipSettings shipSettings;
    // Start is called before the first frame update
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        capsuleCollider = GetComponent<CapsuleCollider>();
        capsuleCollider.enabled = false;
        playerSettings = FindObjectOfType<PlayerSettings>();
        shipSettings = ShipSettings.Instance;
        if (shipSettings != null)
            shipParts = shipSettings.Parts;

        if (shipParts == null || shipParts[1] == null)
        {
            meshRenderer.enabled = true;
            capsuleCollider.enabled = true;
            try
            {
                if (FindObjectOfType<CustomShip>() != null)
                {
                    Destroy(FindObjectOfType<CustomShip>().gameObject);
                }
            } catch (Exception e)
            {

            }
            return;
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            Instantiate(shipParts[i], transform.GetChild(i));
        }

        Destroy(FindObjectOfType<CustomShip>().gameObject);
    }

    // Update is called once per frame
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
