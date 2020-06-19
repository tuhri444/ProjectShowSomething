using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnimationStart : MonoBehaviour
{
    // Start is called before the first frame update
    float timeCounter = 0;

    public float speed;
    public float width;
    public float height;
    void Start()
    {
        speed = 5;
        width = 4;
        height = 7;

    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime* speed;

        float x = Mathf.Cos (timeCounter) * width;
        float y = Mathf.Sin (timeCounter) * height;
        float z = 0;
        transform.position = new Vector3 (x,y,z);
    }
}
