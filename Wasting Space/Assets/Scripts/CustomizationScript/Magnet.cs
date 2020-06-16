using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Magnet : MonoBehaviour
{
    [SerializeField]
    private float force;

    [SerializeField] private List<GameObject> attractable = new List<GameObject>();
    [SerializeField] private bool isAttracting = false;
    private GameObject grabButton;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(grabButton == null)
        {
            grabButton = GameObject.Find("MagnetButton");
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
            if (go != null)
            {
                Rigidbody rb = go.GetComponent<Rigidbody>();
                Vector3 diff = transform.position - go.transform.position;
                Vector3 dir = diff.normalized;
                rb.AddForce(dir * force * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Junk>() != null /*|| other.gameObject.GetComponent<Sattelite>()*/)
        {
            //Debug.Log("Junk has entered");
            attractable.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Junk>() != null /*|| other.gameObject.GetComponent<Sattelite>()*/)
        {
            if (attractable.Contains(other.gameObject))
            {
                //Debug.Log("Junk has left");
                attractable.Remove(other.gameObject);
            }
        }
    }

    //public void Collect(Collider other)
    //{
    //    if(attractable.Contains(other.gameObject) && isAttracting)
    //    {
    //        Debug.Log("Hello");
    //        FindObjectOfType<PlayerSettings>().InternalJunkCollected++;
    //        attractable.Remove(other.gameObject);
    //        Destroy(other.gameObject);
    //    }
    //}
}
