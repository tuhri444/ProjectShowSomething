using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class troll : MonoBehaviour
{
    int counter = 5;
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickedUpon()
    {
        if(counter > 0)
        {
            counter--;
            transform.position = startPos + new Vector3(Random.Range(-200, 200), Random.Range(-200, 200), 0);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
