using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour
{
    private PlayerSettings playerSettings;

    void Start()
    {
        playerSettings = FindObjectOfType<PlayerSettings>();

    }

    void Update()
    {
        
    }

    public void Trigger(Collider other)
    {
        if(playerSettings.InternalJunkCollected > 0)
        {
             
        }
    }
}
