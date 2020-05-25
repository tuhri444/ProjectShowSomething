using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hull : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    private float capacity;
    [SerializeField]
    private float price;

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
