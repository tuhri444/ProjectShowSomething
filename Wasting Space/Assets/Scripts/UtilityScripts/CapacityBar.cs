﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CapacityBar : MonoBehaviour
{

    //Serializable Fields
    [SerializeField]
    private float freeSpace = 50;

    //Non-Serializable Fields
    private Image image;
    private PlayerSettings playerSettings;
    private Hull hull;
    private float hullCap;


    void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        playerSettings = FindObjectOfType<PlayerSettings>();
        hull = FindObjectOfType<Hull>();

    }

    void Update()
    {
        if(hull == null)
        {
            hull = FindObjectOfType<Hull>();
            if (hull != null)
            {
                freeSpace = hull.Capacity;
                hullCap = hull.Capacity;
            }
        }
        image.fillAmount = (freeSpace - playerSettings.InternalJunkCollected)/hullCap;
    }

    public float Capacity
    {
        get { return freeSpace; }
        set { freeSpace = value; }
    }
}
