using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public GameObject Ship;
    public GameObject DropOff;
    float index =0;
    // Start is called before the first frame update
    void Start()
    {
        DropOff = GameObject.Find("Drop-off");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = DropOff.transform.position- Ship.transform.position;
        Vector3 dir = diff.normalized * 5;
        if (diff.magnitude < 15)
        {
            transform.position = DropOff.transform.position;
        }
        else
        {
            transform.position = Ship.transform.position + dir;
        }
    }
}
