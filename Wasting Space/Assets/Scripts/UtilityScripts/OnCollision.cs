using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    Ship ship;
    public void Start()
    {
        ship = GetComponentInParent<Ship>();
    }

    public void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RadarObject" && ship != null)
        {
            Debug.Log("Hit");
            ship.Damage(10);
        }
    }
}
