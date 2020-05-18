using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    //Serializable Fields
    [SerializeField]
    private Transform target;

    [SerializeField]
    [Range(0, .5f)]
    private float smoothSpeed = .1f;

    [SerializeField]
    public Vector3 target_Offset;

    //Non-Serializable Fields
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = transform;
            Debug.Log("No trarget found");
            return;
        }
        target_Offset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x,target.position.y,-10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);

    }
}
