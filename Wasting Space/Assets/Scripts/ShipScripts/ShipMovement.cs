﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //Serializable Fields
    [SerializeField]
    private Joystick joystick;

    //Non-Serializable Fields
    private new Rigidbody rigidbody;
    private PlayerSettings playerSettings;

    private float verticalMove = 0;
    private Vector3 rotationalMove = new Vector2();

    private float verticalInput = 0;
    private float horizontalInput = 0;

    private float speed = 5;
    private float rotationSpeed = 5;
    private float linearDrag = 2.5f;
    private float rotationalDrag = .05f;


    // Start is called before the first frame update
    void Start()
    {
        playerSettings = GetComponent<Ship>().Settings;

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.drag = linearDrag;
        rigidbody.angularDrag = rotationalDrag;

        UpdateStats();
    }

    void Update()
    {
        UpdateStats();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {
            verticalInput = Input.GetAxis("Vertical");
        }
        else if(joystick != null)
        {
            verticalInput = joystick.Vertical;
        }
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            horizontalInput = Input.GetAxis("Horizontal"); 
        }
        else if (joystick != null)
        {
            horizontalInput = joystick.Horizontal;
        }
        VerticalMovement(verticalInput);
        RotationalMovement(new Vector3(0, 0, horizontalInput));  
    }

    void VerticalMovement(float verticalValue)
    {
        verticalMove = verticalValue;
        verticalMove *= speed;
        verticalMove *= Time.fixedDeltaTime;
        rigidbody.AddForce(transform.up * verticalMove, ForceMode.Impulse);
    }
    void RotationalMovement(Vector3 rotationValue)
    {
        rotationalMove = rotationValue;
        rotationalMove *= 10 * rotationSpeed;
        rotationalMove *= Time.fixedDeltaTime;
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, -rotationValue.z * 20, transform.eulerAngles.z);
        transform.Rotate(-rotationalMove);
    }
    void UpdateStats()
    {
        speed = playerSettings.Speed;
        rotationSpeed = playerSettings.RotationSpeed;
        linearDrag = playerSettings.LinearDrag;
        rotationalDrag = playerSettings.RotationalDrag;
    }
}
