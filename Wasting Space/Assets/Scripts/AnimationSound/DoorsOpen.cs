using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsOpen : MonoBehaviour
{
    private AudioSource doorOpen;

    void Awake()
    {
        doorOpen = gameObject.GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        doorOpen.Play();
    }
}
