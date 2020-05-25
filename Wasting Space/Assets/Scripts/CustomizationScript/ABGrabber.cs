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

    protected List<GameObject> Grabslots;
    protected SphereCollider GrabCollider;
    [SerializeField] protected AnimatorStateInfo AnimationInfo;
    [SerializeField] protected Animator AnimController;
    protected Ship ship;

    public abstract void OnClick();
    public abstract void OnTriggerEnter(Collider other);
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
