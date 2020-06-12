using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource Click;
    public AudioSource Whoosh;

    public void PlayClick ()
    {
        Click.Play();
    }

    public void PlayWoosh ()
    {
        Whoosh.Play();
    }
}
