using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eplode : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    Vector3 startPos;
    Quaternion startRot;
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    //void Update()
    //{
    // if(Input.GetKey(KeyCode.Space))
    //    {
    //        transform.position = startPos;
    //        transform.rotation = startRot;
    //        GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("planet"))
        {
            GameObject explosionObj = GameObject.Instantiate(explosion, transform.position, transform.rotation);
            GetComponent<Rigidbody>().AddExplosionForce(0.0000001f, transform.position, 1, 1, ForceMode.Impulse);
        }
    }
}
