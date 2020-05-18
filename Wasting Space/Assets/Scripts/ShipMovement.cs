using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //Serializable Fields
    [SerializeField]
    private float speed = 5;

    //Non-Serializable Fields
    private Vector2 move = new Vector2();
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        move = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        move *= 100*speed;
        move *= Time.deltaTime;
        rigidbody.AddForce(move);

        //if (Mathf.Abs(move.magnitude) < .1f)
        //{
        //    rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.zero, 5f);
        //}
        Debug.Log(rigidbody.velocity);
    }
}
