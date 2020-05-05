using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] int spawnperSecond;
    [SerializeField] GameObject asteroid;
    [SerializeField] GameObject player;
    float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed >= 1)
        {
            GameObject newRock = GameObject.Instantiate(asteroid, transform.position, Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up));
            newRock.GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position).normalized * 2f, ForceMode.Impulse);
            timePassed = 0;
        }
    }
}
