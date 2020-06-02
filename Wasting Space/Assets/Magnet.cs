using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    List<GameObject> attractable = new List<GameObject>();
    bool isAttracting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Q))
        {
            isAttracting = !isAttracting;
        }

        if(isAttracting)
        {
            Attract();
        }
    }

    public void Attract()
    {
        foreach(GameObject go in attractable)
        {
            Rigidbody rb = go.GetComponent<Rigidbody>();
            Vector3 diff = transform.position - go.transform.position;
            Vector3 dir = diff.normalized;
            rb.AddForce(dir,ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Junk>() != null || other.gameObject.GetComponent<Sattelite>())
        {
            attractable.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Junk>() != null || other.gameObject.GetComponent<Sattelite>())
        {
            if (attractable.Contains(other.gameObject))
            {
                attractable.Remove(other.gameObject);
            }
        }
    }
}
