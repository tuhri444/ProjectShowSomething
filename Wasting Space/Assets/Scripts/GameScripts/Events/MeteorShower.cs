using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MeteorShower : MonoBehaviour, WorldEvent
{
    [SerializeField] private float SecondsInBetweenShowers;
    [SerializeField] private int AmountOfMeteors;
    [Range(0.0f,25.0f)] [SerializeField] private float Speed;
    [SerializeField] private List<Condition> Conditions;

    private float TimeInMilli;
    private float TimePassed;
    private bool Activated;

    private GameObject player;
    private List<GameObject> meteoritePrefabs;

    public void Init()
    {
        List<GameObject> prefabs = FindObjectOfType<EventSystem>().Prefabs;
        foreach (GameObject prefabObject in prefabs)
        {
            if(prefabObject.GetComponent<Meteor>())
            {
                meteoritePrefabs.Add(prefabObject);
            }
        }
        TimeInMilli = SecondsInBetweenShowers * 60.0f;
        //player = FindObjectOfType<Ship>();
    }
    public  void Timer()
    {
        if(Activated)
        {
            if(TimePassed > TimeInMilli)
            {
                TimePassed = 0;
                Activated = false;
            }
            TimePassed+=Time.deltaTime;
        }
    }
    public bool CheckCondition()
    {
        foreach (Condition condition in Conditions)
        {
            if (condition.Check()) return true;
        }
        return false;
    }

    public void ActivateEvent()
    {
        if(!Activated)
        {
            Vector3 GeneralSpawnPosition = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), 0);
            GeneralSpawnPosition = player.transform.position + GeneralSpawnPosition;
            for (int i = 0; i < AmountOfMeteors; i++)
            {
                Vector3 randoSpawn = GeneralSpawnPosition + new Vector3(Random.Range(-2.0f,2.0f), Random.Range(-2.0f, 2.0f),0);
                Vector3 target = player.transform.position + new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), 0.0f);
                Vector3 Direction = (target - randoSpawn).normalized;
                GameObject temp = Instantiate(meteoritePrefabs[Random.Range(0, meteoritePrefabs.Count - 1)],randoSpawn,Quaternion.Euler(0,0,0));
                temp.GetComponent<Rigidbody>().AddForce(Direction * Speed);
            }
            Activated = true;
        }
    }
}
