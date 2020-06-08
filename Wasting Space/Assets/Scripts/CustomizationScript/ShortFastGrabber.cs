using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
            Hitbox.GetComponent<SphereCollider>().enabled = true;
            AnimController.SetTrigger(animationNameExtend);
        }
    }

    public override void Trigger(Collider other)
    {
        if (other.gameObject.GetComponent<Junk>())
        {
            Junk otherJunk = other.gameObject.GetComponent<Junk>();
            Hull hull = transform.parent.parent.GetChild(1).GetChild(0).GetComponent<Hull>();

            if (hull != null)
            {
                if (ship.Settings.InternalJunkCollected + otherJunk.GetWorth() <= hull.Capacity && Grabslots.Count == 0)
                {
                    Hitbox.GetComponent<SphereCollider>().enabled = false;
                    otherJunk.GetComponent<BoxCollider>().enabled = false;
                    Grabslots.Add(other.gameObject);
                }
            }
            else
            {
                //throw new System.Exception("Ok so none of the parts actually have a hull script");
            }
        }
    }

    public override void Run()
    {
        AnimationInfo = AnimController.GetCurrentAnimatorStateInfo(0);
        GrabCollider.enabled = CheckColliderState();

        if (Grabslots.Count != 0 && ship.Settings.InternalJunkCollected < shipHull.Capacity)
        {
            if(AnimationInfo.IsTag("re"))
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
            ship.Settings.InternalJunkCollected += item.GetComponent<Junk>().GetWorth();
            Destroy(item);
        }
        Grabslots.Clear();
    }

    private void HoldJunk()
    {
        foreach (GameObject item in Grabslots)
        {
            item.transform.position = Hitbox.transform.position;
            //item.transform.rotation = Hitbox.transform.rotation;
            item.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private bool CheckColliderState()
    {
        if (AnimationInfo.IsTag(animationTagExtended))
        {
            return true;
        }
        else return false;
    }

    void Start()
    {
        ship = FindObjectOfType<Ship>();
        Hitbox.GetComponent<SphereCollider>().enabled = false;

        //GameObject hull = Resources.Load("Parts/Hulls/"+PlayerPrefs.GetString("ActiveHull")) as GameObject;
        Grabslots = new List<GameObject>();
    }

    void Update()
    {
        GameObject grabButton = GameObject.Find("GrabButton");
        if (grabButton != null)
        {
            Button btn = grabButton.GetComponent<Button>();
            btn.onClick.AddListener(OnClick);
        }
        if (shipHull == null)
            shipHull = FindObjectOfType<Hull>();
        else
            Run();
    }
}
