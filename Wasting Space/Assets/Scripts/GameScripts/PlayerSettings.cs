using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
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
    private float junkCollected = 0.0f;
    private float internalJunkCollected = 0.0f;

    private Hull hull;
    private Booster booster;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (hull == null) hull = FindObjectOfType<Hull>();
        else internalJunkCollected = Mathf.Clamp(internalJunkCollected, 0.0f, hull.Capacity);

        if (booster == null)
        {
            booster = FindObjectOfType<Booster>();
        }
        else
        {
            speed = booster.Acceleration; 
            rotationSpeed = booster.AngularAcceleration;
        }

    }

    public float Speed
    { get { return speed; } }
    public float RotationSpeed
    { get { return rotationSpeed; } }
    public float LinearDrag
    { get { return linearDrag; } }
    public float RotationalDrag
    { get { return rotationalDrag; } }

    public float JunkCollected { get => junkCollected; set => junkCollected = value; }
    public float InternalJunkCollected { get => internalJunkCollected; set => internalJunkCollected = value; }
}
