using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundOnEvent : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;

    public AudioClip gloveOn;
    public AudioClip helmetOn;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void PlayGloveOn()
    {
        audioSource.clip = gloveOn;
        audioSource.Play();
    }

    void PlayHelmetOn ()
    {
        audioSource.clip = helmetOn;
        audioSource.Play();
    }
}
