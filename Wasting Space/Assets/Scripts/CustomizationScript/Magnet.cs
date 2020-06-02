using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Magnet : MonoBehaviour
{
    List<GameObject> attractable = new List<GameObject>();
    bool isAttracting = false;
    GameObject grabButton;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(grabButton == null)
        {
            grabButton = GameObject.Find("GrabButton");
            if (grabButton != null)
            {

                grabButton.GetComponent<Button>().onClick.AddListener(ToggleAttract);
            }
        }

        if(Input.GetKeyUp(KeyCode.Q))
        {
            isAttracting = !isAttracting;
        }

        if(isAttracting)
        {
            Debug.Log("Attracting");
            Attract();
        }
    }

    void ToggleAttract()
    {
        isAttracting = !isAttracting;
    }

    public void Attract()
    {
        foreach(GameObject go in attractable)
        {
            Rigidbody rb = go.GetComponent<Rigidbody>();
            Vector3 diff = transform.position - go.transform.position;
            Vector3 dir = diff.normalized;
            rb.AddForce(dir*10,ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Junk>() != null || other.gameObject.GetComponent<Sattelite>())
        {
            Debug.Log("Junk has entered");
            attractable.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Junk>() != null || other.gameObject.GetComponent<Sattelite>())
        {
            if (attractable.Contains(other.gameObject))
            {
                Debug.Log("Junk has left");
                attractable.Remove(other.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(attractable.Contains(other.gameObject))
        {
            FindObjectOfType<PlayerSettings>().InternalJunkCollected++;
            attractable.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
