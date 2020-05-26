using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortFastGrabber : ABGrabber
{
    [SerializeField] private string animationTagResting;
    [SerializeField] private string animationTagExtended;
    [SerializeField] private string animationNameExtend;
    [SerializeField] private string animationNameDextend;
    private Hull shipHull;

    public override void OnClick()
    {
        if (AnimationInfo.IsTag(animationTagResting) && !AnimController.IsInTransition(0))
        {
            AnimController.SetTrigger(animationNameExtend);
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Junk>())
        {
            Junk otherJunk = other.gameObject.GetComponent<Junk>();
            Hull hull = null;
            for (int i = 0; i < ship.GetShipSettings.Parts.Length; i++)
            {
                GameObject part = ship.GetShipSettings.Parts[i];
                if (part.GetComponent<Hull>())
                {
                    hull = part.GetComponent<Hull>();
                }
                else hull = null;
            }
            if (hull != null)
            {
                if (ship.Settings.JunkCollected + otherJunk.GetWorth() <= hull.Capacity)
                {
                    Grabslots.Add(other.gameObject);
                }
            }
            else
            {
                throw new System.Exception("Ok so none of the parts actually have a hull script");
            }
        }
    }

    public override void Run()
    {
        AnimationInfo = AnimController.GetCurrentAnimatorStateInfo(0);
        GrabCollider.enabled = CheckColliderState();

        if (Grabslots.Count != 0 && ship.Settings.JunkCollected < shipHull.Capacity)
        {
            if(AnimationInfo.IsTag("de"))
            {
                CollectJunk();
            }
            else
            {
                HoldJunk();
            }
        }
    }

    private void CollectJunk()
    {
        foreach(GameObject item in Grabslots)
        {
            ship.Settings.JunkCollected += item.GetComponent<Junk>().GetWorth();
            Destroy(item);
        }
        Grabslots.Clear();
    }

    private void HoldJunk()
    {
        foreach (GameObject item in Grabslots)
        {
            item.transform.position = Hitbox.transform.position;
            item.transform.rotation = Hitbox.transform.rotation;
            item.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private bool CheckColliderState()
    {
        if (AnimationInfo.IsTag(animationNameExtend) && !AnimController.IsInTransition(0))
        {
            return true;
        }
        else return false;
    }

    void Start()
    {
        GameObject hull = Resources.Load("Parts/Hulls/"+PlayerPrefs.GetString("ActiveHull")) as GameObject;
        shipHull = hull.GetComponent<Hull>();
        Grabslots = new List<GameObject>();
    }

    void Update()
    {
        Run();
    }
}
