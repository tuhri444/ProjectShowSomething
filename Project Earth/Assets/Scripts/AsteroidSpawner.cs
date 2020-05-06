using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] int ToSpawn;
    [SerializeField] GameObject asteroid;
    [SerializeField] GameObject player;
    [SerializeField] float asteroidSpeed;
    [SerializeField] int seed;
    [SerializeField] bool setSize;
    float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        //Random.InitState(seed);
        for (int i = 0; i < ToSpawn; i++)
        {
            float randomX = Random.Range(-100, 100);
            float randomY = Random.Range(-100, 100);
            Vector3 randomDirection = new Vector3(randomX, randomY);
            GameObject newRock = GameObject.Instantiate(asteroid, randomDirection, Quaternion.identity);
            float size;
            if (setSize)
            {
                size = newRock.GetComponent<Junk>().scale;
            }
            else
            {
                size = Random.Range(0.5f, 3.5f);
            }
            newRock.transform.localScale = new Vector3(size, size, size);
            newRock.GetComponent<Rigidbody>().AddForce(randomDirection.normalized * asteroidSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //timePassed += Time.deltaTime;
        //if(timePassed >= 1)
        //{
        //    for (int i = 0; i < spawnperSecond; i++)
        //    {
        //        Vector3 randomDirection = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0);
        //        GameObject newRock = GameObject.Instantiate(asteroid, transform.position+randomDirection, Quaternion.identity);
        //        newRock.GetComponent<Rigidbody>().AddForce(randomDirection.normalized * asteroidSpeed * Time.deltaTime, ForceMode.Acceleration);
        //    }
        //        timePassed = 0;
        //}
    }
}
