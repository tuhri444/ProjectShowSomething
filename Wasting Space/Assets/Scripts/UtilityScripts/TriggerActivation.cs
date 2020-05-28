using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivation : MonoBehaviour
{
    ShortFastGrabber parentScript;

    private void Start()
    {
        var rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true;
        if (parentScript == null)
            parentScript = FindObjectOfType<ShortFastGrabber>();
    }

    void Update()
    {
        if (parentScript == null)
            parentScript = FindObjectOfType<ShortFastGrabber>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(parentScript!=null)
            parentScript.Trigger(other);
    }
}
