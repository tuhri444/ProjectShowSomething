using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForGrabber : MonoBehaviour
{
    private ShortFastGrabber grabberScript;

    void Start()
    {
        grabberScript = FindObjectOfType<ShortFastGrabber>();    
    }

    void Update()
    {
        
    }

    public void OnClick()
    {
        grabberScript.OnClick();
    }
}
