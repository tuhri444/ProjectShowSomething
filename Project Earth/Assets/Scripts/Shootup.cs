using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootup : MonoBehaviour
{
    [SerializeField] float MainSpeed;
    [SerializeField] float BreakSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] ParticleSystem jetstream;
    [SerializeField] ParticleSystem jetstream2;
    [SerializeField] ParticleSystem jetstream3;
    [SerializeField] ParticleSystem jetstream4;
    [SerializeField] ParticleSystem jetstream5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            jetstream.Play(true);
            GetComponent<Rigidbody>().AddForce(transform.up.normalized* MainSpeed*Time.deltaTime,ForceMode.Impulse);
        }
        else
        {
            jetstream.Stop(true);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, 1), -rotateSpeed * Time.deltaTime);
            jetstream5.Play(true);
        }
        else
        {
            jetstream5.Stop(true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, 1), rotateSpeed * Time.deltaTime);
            jetstream4.Play(true);
        }
        else
        {
            jetstream4.Stop(true);
        }
        if(Input.GetKey(KeyCode.S))
        {
            jetstream2.Play(true);
            jetstream3.Play(true);
            GetComponent<Rigidbody>().AddForce(transform.up.normalized * -BreakSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        else
        {
            jetstream2.Stop(true);
            jetstream3.Stop(true);
        }
    }
}
