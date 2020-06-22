using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAsteroidOut : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Sattelite>())
        {
            Vector3 lineFromSpaceStation = (other.transform.position - transform.position).normalized;
            other.GetComponent<Rigidbody>().AddForce(lineFromSpaceStation * 3 * Time.deltaTime, ForceMode.Acceleration);
        }
    }
}
