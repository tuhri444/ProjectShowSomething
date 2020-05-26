using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventSystem : MonoBehaviour
{
    [SerializeField] private List<WorldEvent> Events;
    [SerializeField] private List<GameObject> prefabs;
    public List<GameObject> Prefabs { get => prefabs;}

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
        if (Events != null)
        {
            foreach (WorldEvent worldEvent in Events)
            {
                worldEvent.Init();
            }
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
