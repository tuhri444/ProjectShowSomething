using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public GameObject Ship;
    public GameObject DropOff;
    public Camera radar;
    public RectTransform rectCanvas;

    [SerializeField] private float distanceFromPlayer = 0.5f;

    Vector3 diff;
    public Vector3 dir;
    Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        DropOff = GameObject.Find("spacestation 2");
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
            GetComponent<SVGImage>().enabled = false;

        }
        else
        {

            GetComponent<SVGImage>().enabled = true;
            float oldZ = transform.position.z;
            transform.position = Ship.transform.position + dir;
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
}
