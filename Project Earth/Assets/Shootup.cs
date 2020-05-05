using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootup : MonoBehaviour
{
    [SerializeField] float SPEEEEEEEEEEEED;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(transform.up.normalized*SPEEEEEEEEEEEED*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            GetComponent<Rigidbody>().AddForce(-transform.up.normalized * SPEEEEEEEEEEEED * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, 1), -0.1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, 1), 0.1f);
        }
    }
}
