using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HumanShock : MonoBehaviour
{
    private AudioSource alarm;

    void Awake ()
    {
        alarm = gameObject.GetComponent<AudioSource> ();
    }

    void OnEnable ()
    {
        alarm.Play();
    }
}
