using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  ABGrabber : MonoBehaviour
{
    public MeshCollider Hitbox;
    public int GrabCapacity;
    public float Price;

    public abstract void OnClick();
    public abstract void OnTriggerEnter();
    public abstract void Run();
}
