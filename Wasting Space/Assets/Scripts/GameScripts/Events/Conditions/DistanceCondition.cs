using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCondition : MonoBehaviour , Condition
{
    Ship player;
    DropOff spaceStation;

    private void Start()
    {
        player = FindObjectOfType<Ship>();
        spaceStation = FindObjectOfType<DropOff>(); 
    }
    public bool Check()
    {
        if (player == null) player = FindObjectOfType<Ship>();
        if (spaceStation == null) spaceStation = FindObjectOfType<DropOff>();
        if (Vector3.Distance(player.transform.position, spaceStation.transform.position) > 10) return true;
        else return false;
    }
}
