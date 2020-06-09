using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hull : MonoBehaviour
{
    [SerializeField]
    private float health=0;
    [SerializeField]
    private float capacity=0;
    [SerializeField]
    private float price=0;

    public float Health
    {
        get { return health; }
    }
    public float Capacity
    {
        get { return capacity; }
    }
    public float Price
    { 
        get { return price; } 
    }
}
