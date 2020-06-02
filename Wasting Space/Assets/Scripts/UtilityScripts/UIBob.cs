using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIBob : MonoBehaviour
{
    [SerializeField]
    private float amplitude;

    [SerializeField]
    private float speed;
    private Vector3 startPosition;
    private System.Random rnd;
    private int randNum;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rnd = new System.Random();
        randNum = rnd.Next();
    }

    // Update is called once per frame
    void Update()
    { 
        randNum++;
        transform.position = startPosition + new Vector3(0, Mathf.Sin(speed * randNum) * amplitude, 0);
    }
}
