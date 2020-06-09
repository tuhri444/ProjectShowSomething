using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivation : MonoBehaviour
{
    ABGrabber parentScript;

    private void Start()
    {
        var rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if (parentScript == null)
        {
            if (FindObjectOfType<ShortFastGrabber>())
                parentScript = FindObjectOfType<ShortFastGrabber>();
            else if (FindObjectOfType<LongSlowGrabber>())
                parentScript = FindObjectOfType<LongSlowGrabber>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(parentScript!=null)
            parentScript.Trigger(other);
    }
}
