using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerParentScript : MonoBehaviour
{
    private DropOff dropOffScript;
    void Start()
    {
        dropOffScript = GetComponentInParent<DropOff>();
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        dropOffScript.Trigger(other);
    }
}
