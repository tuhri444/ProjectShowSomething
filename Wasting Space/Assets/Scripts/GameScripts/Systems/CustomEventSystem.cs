using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomEventSystem : MonoBehaviour
{
    [SerializeField] private List<WorldEvent> events;
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] public List<Condition> conditions;
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
                if (eventObjects.GetComponent<MeteorShower>()) events.Add(eventObjects.GetComponent<MeteorShower>());
                else Debug.Log("couldn't find meteorshower script");              
            }
            if (Events != null)
            {
                foreach (WorldEvent worldEvent in Events)
                {
                    Debug.Log("This part is working");
                    worldEvent.Init();
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
