using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortFastGrabber : ABGrabber
{
    [SerializeField] private string animationTagResting;
    [SerializeField] private string animationTagExtended;
    [SerializeField] private string animationNameExtend;
    [SerializeField] private string animationNameDextend;

    public override void OnClick()
    {
    //    if (AnimationInfo.IsTag(animationTagResting) && !AnimController.IsInTransition(0))
    //    {
    //        AnimController.SetTrigger(animationNameExtend);
    //    }
    }

    public override void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.GetComponent<Junk>())
        //{
        //    Junk otherJunk = other.gameObject.GetComponent<Junk>();
        //    Hull hull = null;
        //    for (int i = 0; i < ship.GetShipSettings.Parts.Length; i++)
        //    {
        //        GameObject part = ship.GetShipSettings.Parts[i];
        //        if (part.GetComponent<Hull>())
        //        {
        //            hull = part.GetComponent<Hull>();
        //        }
        //        else hull = null;
        //    }
        //    if(hull !=null)
        //    {
        //        if (ship.Settings.JunkCollected + otherJunk.GetWorth() <= hull.Capacity)
        //        {
        //            Grabslots.Add(other.gameObject);
        //        }
        //    }
        //    else
        //    {
        //        throw new System.Exception("Ok so none of the parts actually have a hull script");
        //    }
        //}
    }

    public override void Run()
    {
        //AnimationInfo = AnimController.GetCurrentAnimatorStateInfo(0);
        //GrabCollider.enabled = CheckColliderState();
        
    }

    private bool CheckColliderState()
    {
        if (AnimationInfo.IsTag(animationNameExtend) && !AnimController.IsInTransition(0))
        {
            return true;
        }
        else return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Grabslots = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(AnimationI)
    }
}
