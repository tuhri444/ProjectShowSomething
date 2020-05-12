using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public GameObject Ship;
    public GameObject DropOff;
    float index =0;
    public RectTransform rectCanvas;

    [SerializeField] private float distanceFromPlayer = 0.5f;

    Vector3 diff;
    public Vector3 dir;
    Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        DropOff = GameObject.Find("Drop-off");
        Canvas canvas = FindObjectOfType<Canvas>();
        rectCanvas = canvas.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        diff = DropOff.transform.position- Ship.transform.position;
        dir = diff.normalized * distanceFromPlayer;
        if (diff.magnitude < 15)
        {
            transform.position = new Vector3(-300,-300, transform.position.z);
        }
        else
        {
            float oldZ = transform.position.z;
            transform.position = /*new Vector3(rectCanvas.sizeDelta.x * 0.5f, rectCanvas.sizeDelta.y*0.5f,0)*/Ship.transform.position + dir;
            transform.position = new Vector3(transform.position.x, transform.position.y, oldZ);
        }
    }
}
