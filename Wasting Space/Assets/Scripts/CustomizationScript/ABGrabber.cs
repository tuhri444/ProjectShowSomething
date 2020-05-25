using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  ABGrabber : MonoBehaviour
{
    public MeshCollider Hitbox;
    public int GrabCapacity;
    public float Price;

    protected List<GameObject> Grabslots;
    protected SphereCollider GrabCollider;
    [SerializeField] protected AnimatorStateInfo AnimationInfo;
    [SerializeField] protected Animator AnimController;
    protected Ship ship;

    public abstract void OnClick();
    public abstract void OnTriggerEnter(Collider other);
    public abstract void Run();
}
