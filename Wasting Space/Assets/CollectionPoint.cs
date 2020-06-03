using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Junk>() != null/* || other.gameObject.GetComponent<Sattelite>()*/)
        {
            GetComponentInParent<Magnet>().Collect(other);
        }
    }
}
