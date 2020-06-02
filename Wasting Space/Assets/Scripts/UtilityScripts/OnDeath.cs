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
        GameObject endMenu = Resources.Load("EndMenu") as GameObject;
        Instantiate(endMenu, canvas.transform);
        //SceneManager.LoadScene(3);
    }

    private void Start()
    {
        //LoadScores();

        //SaveScores();
    }

}
