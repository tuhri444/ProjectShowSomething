using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDeath : MonoBehaviour
{

    [SerializeField]
    private Canvas canvas;

    private void OnDestroy()
    {
        FindObjectOfType<StopTheGame>().ActiveTheEnd();
        GameObject endMenu = Resources.Load("EndMenu") as GameObject;
        Instantiate(endMenu, canvas.transform);
    }

    private void Start()
    {
    }

}
