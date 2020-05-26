using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivation : MonoBehaviour
{
    ShortFastGrabber parentScript;
    void Update()
    {
        if (parentScript == null)
            parentScript = FindObjectOfType<ShortFastGrabber>();
    }

    private void OnTriggerEnter(Collider other)
    {
        parentScript.Trigger(other);
    }
}
