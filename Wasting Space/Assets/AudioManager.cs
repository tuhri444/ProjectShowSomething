﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Sounds")]
    public AudioClip gameOver;
    public AudioClip capacityFull;
    public AudioClip collision;

    [Header("Special")]
    public GameObject shipGo;
    public AudioSource thruster;
    public AudioSource lowHealth;
    public AudioSource unloading;

    [Header("Settings")]
    [Range(0, 1)]
    public float volume = 1;

    private Rigidbody shipRb;
    private Ship ship;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = volume;

        shipRb = shipGo.GetComponent<Rigidbody>();
        ship = shipGo.GetComponent<Ship>();
    }

    private void Update()
    {
        float temp = 1.0f / 3.8f * shipRb.velocity.magnitude;
        PlayThrusterSound(temp);
        UpdateUnloadingSound(temp);
        PlayLowHealthSound(ship.GetHealth());
    }

    public void PlayGameOverSound()
    {
        PlayClip(gameOver);
    }

    public void PlayCapacityFullSound()
    {
        PlayClip(capacityFull);
    }

    public void PlayCollisionSound()
    {
        PlayClip(collision);
    }

    private void PlayThrusterSound(float speed)
    {
        if (speed > 0.3f && !thruster.isPlaying)
        {
            thruster.Play();
        }
        else if (speed <= 0.3f && thruster.isPlaying)
        {
            thruster.Stop();
        }
    }

    private void PlayLowHealthSound(float health)
    {
        if (ship.died)
        {
            if (lowHealth.isPlaying)
            {
                lowHealth.Stop();
            }

            return;
        }

        if (health > 30 && lowHealth.isPlaying)
        {
            lowHealth.Stop();
        }
        else if (health <= 30 && !lowHealth.isPlaying)
        {
            lowHealth.Play();
        }
    }

    private void UpdateUnloadingSound(float speed)
    {
        if (unloading.isPlaying && speed > 0.3f)
        {
            unloading.Stop();
        }
    }

    private void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}