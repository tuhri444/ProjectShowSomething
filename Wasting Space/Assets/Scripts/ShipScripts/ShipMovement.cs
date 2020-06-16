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
    [SerializeField]
    private bool DragControls = false;
    [SerializeField]
    private Camera cam;

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

    public bool EnableMovement = true;

    // Start is called before the first frame update
    void Start()
    {
        playerSettings = FindObjectOfType<PlayerSettings>();

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
        if (EnableMovement)
        {
            if (DragControls)
            {
                if (Input.GetMouseButton(0))
                {
                    Vector2 direction = Vector3.one;
                    direction.x = Input.mousePosition.x - Screen.width * 0.5f;
                    direction.y = Input.mousePosition.y - Screen.height * 0.5f;
                    DirectionMove(direction.normalized);
                }
            }
            else
            {
                if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
                {
                    verticalInput = Input.GetAxis("Vertical");
                }
                else if (joystick != null)
                {
                    verticalInput = joystick.Vertical;
                }

                if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
                {
                    horizontalInput = Input.GetAxis("Horizontal");
                }
                else if (joystick != null)
                {
                    horizontalInput = joystick.Horizontal;
                }

                if (!tankControls)
                {
                    DirectionMove(new Vector2(verticalInput, -horizontalInput).Rotate(90));
                }
                else
                {
                    VerticalMovement(verticalInput);
                    RotationalMovement(new Vector3(0, 0, horizontalInput));
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioManager.instance.PlayCollisionSound();
    }

    void DirectionMove(Vector2 movementDirection)
    {
        float x = movementDirection.x;
        float y = movementDirection.y;

        if (movementDirection.sqrMagnitude > 0.1)
        {
            float angle = Mathf.Atan2(x, y) * Mathf.Rad2Deg;
            var targetRotation = Quaternion.Euler(new Vector3(0, 0, -angle));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            rigidbody.AddForce(transform.up * speed * Time.deltaTime, ForceMode.Impulse);
        }
    }
    void VerticalMovement(float verticalValue)
    {
        verticalMove = verticalValue;
        verticalMove *= speed;
        verticalMove *= Time.deltaTime;
        rigidbody.AddForce(transform.up * verticalMove, ForceMode.Impulse);
    }
    void RotationalMovement(Vector3 rotationValue)
    {
        rotationalMove = rotationValue;
        rotationalMove *= 10 * rotationSpeed;
        rotationalMove *= Time.deltaTime;
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
