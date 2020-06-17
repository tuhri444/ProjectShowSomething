using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource Click;
    public AudioSource Whoosh;
    public AudioSource Grabber;
    public AudioSource Magnet;
    public AudioSource Docking;
    public AudioSource Unloading;
    public AudioSource Launch;

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

    public void PlayDocking()
    {
        Docking.Play();
    }

    public void PlayUnloading()
    {
        StartCoroutine(UnloadingCourotine());
    }

    public void PlayLaunch()
    {
        Launch.Play();
    }

    IEnumerator UnloadingCourotine ()
    {
        yield return new WaitForSeconds(1f);

        Unloading.Play();
    }
}
