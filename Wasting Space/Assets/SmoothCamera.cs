using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    [Range(0, .5f)]
    private float time = .1f;
    [SerializeField]
    private float range = 10;
    [SerializeField]
    public Vector3 target_Offset;

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
    void Update()
    {
        Vector2 diff = target.position - transform.position;
        if (diff.magnitude < range)
        {
            // Define a target position above and behind the target transform
            Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -10));

            // Smoothly move the camera towards that target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, time);

        }
        else
        {
            transform.position = Vector3.Max(transform.position,new Vector3(target.position.x+diff.x,target.position.y+diff.y,-range));
        }
    }
}
