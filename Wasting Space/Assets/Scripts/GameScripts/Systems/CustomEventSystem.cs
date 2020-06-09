using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomEventSystem : MonoBehaviour
{
    [SerializeField] private List<WorldEvent> events;
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] public List<Condition> conditions;
    public GameObject HotFixCondition;
    public List<GameObject> Prefabs { set => prefabs = value; get => prefabs; }
    public List<bool> editorSaveSpace;
    public List<WorldEvent> Events { get => events;}

    private void Start()
    {
        InitializeEvents();
    }
    private void Update()
    {
        UpdateEvents();
        CheckEvents();
    }
    private void InitializeEvents()
    {
        events = new List<WorldEvent>();
        if(prefabs != null)
        {
            foreach(GameObject eventObjects in Prefabs)
            {
                GameObject temp = Instantiate(eventObjects);
                temp.transform.parent = transform;
                if (temp.GetComponent<MeteorShower>()) events.Add(temp.GetComponent<MeteorShower>());
                else Debug.Log("couldn't find meteorshower script");              
            }
            if (events != null)
            {
                foreach (WorldEvent worldEvent in events)
                {
                    Debug.Log("This part is working");
                    worldEvent.Init(HotFixCondition.GetComponent<Condition>());
                }
            }
        }
        else
        {
            Debug.Log("No events found");
        }
        
    }
    private void UpdateEvents()
    {
        if (Events != null)
        {
            foreach (WorldEvent worldEvent in Events)
            {
                worldEvent.Timer();
            }
        }
    }
    private void CheckEvents()
    {
        if (Events != null)
        {
            foreach (WorldEvent worldEvent in Events)
            {
                if (worldEvent.CheckCondition()) ActiveEvent(worldEvent);
            }
        }
    }
    private void ActiveEvent(WorldEvent _eventToActivate)
    {
         _eventToActivate.ActivateEvent();
    }
}
