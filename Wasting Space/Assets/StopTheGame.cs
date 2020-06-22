using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTheGame : MonoBehaviour
{
    public bool Activated { get; private set; } = false;
    
    public void ActiveTheEnd()
    {
        Activated = true;
    }
}
