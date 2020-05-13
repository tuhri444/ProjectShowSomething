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

    [HideInInspector]
    public Nose nose;
    [HideInInspector]
    public Body mainBody;
    [HideInInspector]
    public Booster booster;

    bool hasReplaced;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        init();
    }

    private void Update()
    {
        if (FindObjectOfType<BodyToReplace>() && !hasReplaced)
        {
            transform.parent = FindObjectOfType<BodyToReplace>().transform;
            Vector3 oldPos = transform.position;
            oldPos.x = 0;
            transform.position = oldPos;
            hasReplaced = true;
        }
    }
    public void init()
    {
        hasReplaced = false;
        if (nose == null)
        {
            nose = GetComponentInChildren<Nose>();
        }
        if (mainBody == null)
        {
            mainBody = GetComponentInChildren<Body>();
        }
        if (booster == null)
        {
            booster = GetComponentInChildren<Booster>();
        }
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
