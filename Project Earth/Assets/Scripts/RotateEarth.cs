using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float rotateSpeed = 5;
    float left= 0;
    float right = 0;
    float up = 0;
    float down = 0;
    float hor;
    float vert;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hor = 0;
        vert = 0;
        left = Input.GetKey(KeyCode.A) ? 1 : 0;
        right = Input.GetKey(KeyCode.D) ? 1 : 0;
        up = Input.GetKey(KeyCode.W) ? 1 : 0;
        down = Input.GetKey(KeyCode.S) ? 1 : 0;

        hor += (right - left) * rotateSpeed;
        vert += (up - down) * rotateSpeed;

        transform.Rotate(new Vector3(0, 1, 0), hor);
        //transform.Rotate(new Vector3(1, 0, 0), vert);
    }
}
