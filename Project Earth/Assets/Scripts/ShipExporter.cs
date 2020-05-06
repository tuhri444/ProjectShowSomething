using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipExporter : MonoBehaviour
{
    [SerializeField]
    private GameObject head;
    [SerializeField]
    private GameObject body;
    [SerializeField]
    private GameObject thruster;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public GameObject Head
    {
        get { return head; }
        set { head = value; }
    }
    public GameObject Body
    {
        get { return body; }
        set { body = value; }
    }
    public GameObject Thruster
    {
        get { return thruster; }
        set { thruster = value; }
    }

}
