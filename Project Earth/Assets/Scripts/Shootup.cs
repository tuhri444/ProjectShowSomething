﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootup : MonoBehaviour
{
    [SerializeField] float SPEEEEEEEEEEEED;
    [SerializeField] float rotateSpeed;
    [SerializeField] ParticleSystem jetstream;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            if (jetstream.isStopped) jetstream.Play(true);
            GetComponent<Rigidbody>().AddForce(transform.up.normalized*SPEEEEEEEEEEEED);
        }
        else
        {
            if (jetstream.isPlaying) jetstream.Stop(true);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, 1), -rotateSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, 1), rotateSpeed);
        }
    }
}
