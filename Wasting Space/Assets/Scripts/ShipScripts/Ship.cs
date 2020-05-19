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
    // Start is called before the first frame update
    private void Start()
    {
        playerSettings = GameObject.Find("PlayerSettings").GetComponent<PlayerSettings>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "RadarObject")
        {
            health-=10;
        }
    }

    public PlayerSettings Settings
    {
        get { return playerSettings; }
    }
}
