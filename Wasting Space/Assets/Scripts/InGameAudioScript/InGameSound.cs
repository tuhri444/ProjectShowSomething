using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InGameSound : MonoBehaviour
{
    private AudioSource grabberSound;
    private AudioSource magnetSound;

    void Awake()
    {
        grabberSound = gameObject.GetComponent<AudioSource>();
        magnetSound = gameObject.GetComponent<AudioSource>();
    }

    public void soundGrabber()
    {
        grabberSound.Play();
    }

    public void soundMagnet ()
    {
        magnetSound.Play();
    }
}


