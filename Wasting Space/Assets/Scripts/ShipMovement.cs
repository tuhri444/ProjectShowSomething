using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //Serializable Fields
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float rotationSpeed = 5;

    [SerializeField]
    private float linearDrag = 2.5f;

    [SerializeField]
    private float rotationalDrag = .05f;

    //Non-Serializable Fields
    private float verticalMove = 0;
    private Vector3 rotationalMove = new Vector2();
    private new Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.drag = linearDrag;
        rigidbody.angularDrag = rotationalDrag;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotationalMove = new Vector3(0, 0, Input.GetAxis("Horizontal"));
        rotationalMove *= 10 * rotationSpeed;
        rotationalMove *= Time.fixedDeltaTime;
        transform.Rotate(-rotationalMove);

        verticalMove = Input.GetAxis("Vertical");
        verticalMove *= speed;
        verticalMove *= Time.fixedDeltaTime;
        rigidbody.AddForce(transform.up * verticalMove, ForceMode.Impulse);

        Debug.Log(transform.up);
    }
}
