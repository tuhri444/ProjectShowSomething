using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator controller;
    [SerializeField] Hull hull;
    private List<GameObject> grabSlot;
    private SphereCollider collider;
    void Start()
    {
        collider = GetComponent<SphereCollider>();
        grabSlot = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo info = controller.GetCurrentAnimatorStateInfo(0);
        if (info.IsTag("rest") && Input.GetMouseButtonDown(0) && !controller.IsInTransition(0))
        {
            controller.SetTrigger("extendArm");
        }
        else if (info.IsTag("ex") && Input.GetMouseButtonDown(0) && !controller.IsInTransition(0))
        {
            controller.SetTrigger("dextendArm");
        }
        if(info.IsTag("ex") && !controller.IsInTransition(0))
        {
            collider.enabled = true;
        }
        else
        {
            collider.enabled = false;
        }

        if (grabSlot.Count != 0)
        {
            if (info.IsTag("de"))
            {
                GameObject item = grabSlot[0];
                hull.score += item.GetComponent<Junk>().score;
                grabSlot.Clear();
                Destroy(item);
            }
            else
            {
                grabSlot[0].transform.position = transform.position;
                grabSlot[0].transform.rotation = transform.rotation;
                grabSlot[0].GetComponent<BoxCollider>().enabled = false;
            }
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("junk") && grabSlot.Count == 0)
        {
            grabSlot.Add(other.gameObject);
        }
    }
    
}
