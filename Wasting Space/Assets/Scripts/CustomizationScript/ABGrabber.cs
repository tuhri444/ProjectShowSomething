using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  ABGrabber : MonoBehaviour
{
    [SerializeField]
    private MeshCollider hitbox;
    [SerializeField]
    private int grabCapacity;
    [SerializeField]
    private float price;

    public abstract void OnClick();
    public abstract void OnTriggerEnter();
    public abstract void Run();

    public MeshCollider Hitbox
    {
        get { return hitbox; }
    }
    public int GrabCapacity
    {
        get { return grabCapacity; }
    }
    public float Price
    { 
        get { return price; } 
    }
}
