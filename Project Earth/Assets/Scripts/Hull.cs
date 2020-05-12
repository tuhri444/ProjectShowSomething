using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hull : MonoBehaviour
{
    public ShipExporter exporter;
    public int maxHp = 100;
    public int hp;
    public int capacity = 10;
    public int junkCollected = 0;

    void Start()
    {
      
    }
    void Update()
    { 
        if(exporter == null)
        {
            exporter = GameObject.Find("Ship").GetComponent<ShipExporter>();
            exporter.init();
            Shootup shootUp = GameObject.Find("ship").GetComponent<Shootup>();
            Debug.Log(exporter);
            Debug.Log(exporter.nose);
            Debug.Log(exporter.nose.capacity);
            capacity = exporter.nose.capacity;
            maxHp += exporter.mainBody.health;
            shootUp.modifySpeed(exporter.booster.speed);
            hp = maxHp;
        }

        
        if (hp <= 0)
        {
            Application.LoadLevel(3);
        }
    }
}
