using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private Animator animController;

    void Start()
    {
        animController = GetComponent<Animator>();
    }

    public void PlayShake()
    {
        animController.SetTrigger("Shake");
    }
}
