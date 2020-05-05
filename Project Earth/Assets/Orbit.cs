using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{

    [SerializeField] Transform rotationpoint;
    [SerializeField] float increment;
    [SerializeField] float radius;
    [SerializeField] Vector3 Axis;
    [SerializeField] bool canChangeValues;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canChangeValues)
        {
            if(Input.GetKey(KeyCode.A))
            {
                increment -= 0.1f;
            }
            else if(Input.GetKey(KeyCode.D))
            {
                increment += 0.1f;
            }

            if(Input.GetKey(KeyCode.W))
            {
                radius += 0.1f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                radius -= 0.1f;
            }
        }
        transform.RotateAround(rotationpoint.position, Axis, increment * Time.deltaTime);
        Vector3 desiredPosition = (transform.position - rotationpoint.position).normalized * radius + rotationpoint.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * increment);

    }
}
