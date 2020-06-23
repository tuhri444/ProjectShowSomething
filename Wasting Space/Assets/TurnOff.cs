﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    [SerializeField] private GameObject objectToTurnOff;
    public void TurnOffObject()
    {
        objectToTurnOff.SetActive(false);
    }
}
