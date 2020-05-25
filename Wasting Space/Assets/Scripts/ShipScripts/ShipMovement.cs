using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //Serializable Fields
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private bool tankControls = false;

    //Non-Serializable Fields
    private new Rigidbody rigidbody;
    private PlayerSettings playerSettings;
    private Camera mainCamera;

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
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

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

        if (!tankControls)
        {
            DirectionMove(new Vector3(verticalInput, -horizontalInput, 0));
        }
        else
        {
            VerticalMovement(verticalInput);
            RotationalMovement(new Vector3(0, 0, horizontalInput));  
        }

    }

    void DirectionMove(Vector3 movementDirection)
    {
        float x = movementDirection.x;
        float y = movementDirection.y;
        if (movementDirection.sqrMagnitude > 0.1)
        {
            float angle = Mathf.Atan2(x, y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, -(angle-90))), Time.deltaTime * rotationSpeed);
            rigidbody.AddForce(transform.up*speed*Time.deltaTime, ForceMode.Impulse);
        }
        //if (x == 0f && y == 0f)
        //{ // this statement allows it to recenter once the inputs are at zero 
        //    Vector3 curRot = transform.localEulerAngles; // the object you are rotating
        //    Vector3 homeRot;
        //    if (curRot.y > 180f)
        //    { // this section determines the direction it returns home 
        //        Debug.Log(curRot.y);
        //        homeRot = new Vector3(0f, 359.999f, 0f); //it doesnt return to perfect zero 
        //    }
        //    else
        //    {                                                                      // otherwise it rotates wrong direction 
        //        homeRot = Vector3.zero;
        //    }
        //    transform.localEulerAngles = Vector3.Slerp(curRot, homeRot, Time.deltaTime * 2);
        //}
        //else
        //{
        //     transform.localEulerAngles = new Vector3(0f, Mathf.Atan2(x, y) * 180 / Mathf.PI, 0f);// this does the actual rotaion according to inputs
        //}
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
