using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hull : MonoBehaviour
{
    public ShipExporter exporter;
    public float maxHp = 100;
    public float hp;
    public float capacity = 10;
    public float junkCollected = 0;

    void Start()
    {
      
    }
    void Update()
    { 
        if(exporter == null)
        {
            exporter = FindObjectOfType<ShipExporter>();
            exporter.init();

            Vector3 pos = exporter.transform.position;
            pos.x = 0;
            exporter.transform.position = pos;

            Shootup shootUp = GameObject.Find("ship").GetComponent<Shootup>();
            Debug.Log(exporter);
            Debug.Log(exporter.nose);
            Debug.Log(exporter.nose.capacity);

            Vector3 posNose = exporter.nose.transform.position;
            posNose.x = 0;
            exporter.nose.transform.position = posNose;
            Vector3 posHull = exporter.mainBody.transform.position;
            posHull.x = 0;
            exporter.mainBody.transform.position = posHull;
            Vector3 posBooster = exporter.booster.transform.position;
            posBooster.x = 0;
            exporter.booster.transform.position = posBooster;

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
