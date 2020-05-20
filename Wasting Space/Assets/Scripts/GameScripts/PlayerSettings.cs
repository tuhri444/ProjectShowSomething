using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float Speed
    { get { return speed; } }
    public float RotationSpeed
    { get { return rotationSpeed; } }
    public float LinearDrag
    { get { return linearDrag; } }
    public float RotationalDrag
    { get { return rotationalDrag; } }
}
