using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField]
    private float accelerationSpeed;
    [SerializeField]
    private float rototationSpeed;
    [SerializeField]
    private float price;

    public float Acceleration
    {
        get { return accelerationSpeed; }
    }

    public float AngularAcceleration
    {
        get { return rototationSpeed; }
    }

    public float Price
    {
        get { return price; }
    }
}
