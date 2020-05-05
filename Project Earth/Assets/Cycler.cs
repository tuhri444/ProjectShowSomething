using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cycler : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Heads;
    [SerializeField]
    private List<GameObject> Bodies;
    [SerializeField]
    private List<GameObject> Thrusters;

    private GameObject ship;
    private GameObject headPlaceholder;
    private GameObject bodyPlaceholder;
    private GameObject thrusterPlaceholder;
    private List<GameObject> headList = new List<GameObject>();
    private List<GameObject> bodyList = new List<GameObject>();
    private List<GameObject> thrusterList = new List<GameObject>();
    private int headIndex = 0;
    private int bodyIndex = 0;
    private int thrusterIndex = 0;

    private Vector3 offset = new Vector3(15, 0, 0);
    public float time = 1;

    // Start is called before the first frame update
    void Start()
    {

        ship = GameObject.Find("Ship").gameObject;
        headPlaceholder = ship.transform.Find("HeadPlaceholder").gameObject;
        bodyPlaceholder = ship.transform.Find("BodyPlaceholder").gameObject;
        thrusterPlaceholder = ship.transform.Find("ThrusterPlaceholder").gameObject;

        for (int i = 0; i < Heads.Count; i++)
        {
            GameObject head = Instantiate(Heads[i], headPlaceholder.transform);
            head.transform.Translate(i * 15, 0, 0);
            headList.Add(head);
        }
        for (int i = 0; i < Bodies.Count; i++)
        {
            GameObject body = Instantiate(Bodies[i], bodyPlaceholder.transform);
            body.transform.Translate(i * 15, 0, 0);
            bodyList.Add(body);
        }
        for (int i = 0; i < Thrusters.Count; i++)
        {
            GameObject thruster = Instantiate(Thrusters[i], thrusterPlaceholder.transform);
            thruster.transform.Translate(i * 15, 0, 0);
            thrusterList.Add(thruster);

        }

        headIndex = headList.Count;
        bodyIndex = bodyList.Count;
        thrusterIndex = thrusterList.Count;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LeftHead()
    {
        headIndex--;
        if (headIndex < 1)
        {
            headIndex = 1;
            return;
        }
        foreach (GameObject head in headList)
        {
            LeanTween.move(head, head.transform.position + -offset, time);
        }
    }
    public void RightHead()
    {
        headIndex++;
        if (headIndex > headList.Count)
        {
            headIndex = headList.Count;
            return;
        }
        foreach (GameObject head in headList)
        {
            LeanTween.move(head, head.transform.position + offset, time);
        }
    }

    public void LeftBody()
    {
        bodyIndex--;
        if (bodyIndex < 1)
        {
            bodyIndex = 1;
            return;
        }
        foreach (GameObject body in bodyList)
        {
            LeanTween.move(body, body.transform.position + -offset, time);
        }
    }
    public void RightBody()
    {
        bodyIndex++;
        if (bodyIndex > bodyList.Count)
        {
            bodyIndex = bodyList.Count;
            return;
        }
        foreach (GameObject body in bodyList)
        {
            LeanTween.move(body, body.transform.position + offset, time);
        }
    }

    public void LeftThruster()
    {
        thrusterIndex--;
        if (thrusterIndex < 1)
        {
            thrusterIndex = 1;
            return;
        }
        foreach (GameObject thruster in thrusterList)
        {
            LeanTween.move(thruster, thruster.transform.position + -offset, time);
        }
    }
    public void RightThruster()
    {
        thrusterIndex++;
        if (thrusterIndex > thrusterList.Count)
        {
            thrusterIndex = thrusterList.Count;
            return;
        }
        foreach (GameObject thruster in thrusterList)
        {
            LeanTween.move(thruster, thruster.transform.position + offset, time);
        }
    }
}
