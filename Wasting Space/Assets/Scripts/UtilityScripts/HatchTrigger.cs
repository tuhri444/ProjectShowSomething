using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
       meshRenderer.enabled = true;
    }
    private void OnTriggerExit(Collider other)
    {
        meshRenderer.enabled = false;
    }

}
