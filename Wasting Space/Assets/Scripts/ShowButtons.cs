using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButtons : MonoBehaviour
{
    [SerializeField] private List<GameObject> buttons;
    private DropOff spaceStation;
    private Ship player;
    private Vector3 spaceStationLocation;
    void Start()
    {
        spaceStation = FindObjectOfType<DropOff>();
        player = FindObjectOfType<Ship>();
        spaceStationLocation = spaceStation.transform.position;
        spaceStationLocation.z = 0;
    }

    void Update()
    {
        if(Vector3.Distance(player.transform.position,spaceStationLocation) < 3.0f && !spaceStation.GetLockIn)
        {
            buttons[0].SetActive(true);
        }
        else
        {
            buttons[0].SetActive(false);
        }
        if(spaceStation.GetLockIn)
        {
            buttons[1].SetActive(true);
        }
        else
        {
            buttons[1].SetActive(false);
        }
    }
}
