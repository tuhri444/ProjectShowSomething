using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource Click;
    public AudioSource Whoosh;
    public AudioSource Grabber;
    public AudioSource Magnet;

    public void PlayClick ()
    {
        Click.Play();
    }

    public void PlayWoosh ()
    {
        Whoosh.Play();
    }

    public void PlayGrabber ()
    {
        Grabber.Play();
    }

    public void PlayMagnet ()
    {
        Magnet.Play();
    }
}
