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
    private int timesActivated;
    private float TimeInMilli;
    [SerializeField] private float TimePassed;
    [SerializeField] private bool Activated;

    private GameObject player;
    [SerializeField] private List<GameObject> meteoritePrefabs;

    public void Init(Condition _condition)
    {
        Conditions = new List<Condition>();
        Conditions.Add(_condition);
        List<GameObject> prefabs = FindObjectOfType<CustomEventSystem>().Prefabs;
        TimeInMilli = SecondsInBetweenShowers;
        player = FindObjectOfType<Ship>().transform.gameObject;
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
        return Conditions[0].Check();
        //foreach (Condition condition in Conditions)
        //{
        //    if (condition.Check()) return true;
        //}
        //return false;
    }

    public void ActivateEvent()
    {
        if (!Activated)
        {
            //Debug.Log("Activating event " + timesActivated);
            Vector3 GeneralSpawnPosition = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), 0).normalized * 30.0f;
            GeneralSpawnPosition = player.transform.position + GeneralSpawnPosition;
            for (int i = 0; i < AmountOfMeteors; i++)
            {
                Vector3 randoSpawn = GeneralSpawnPosition + new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), 0);
                Vector3 target = player.transform.position;
                Vector3 Direction = (target - randoSpawn).normalized;
                GameObject temp = Sattelite.CreateSattelite(meteoritePrefabs[Random.Range(0, meteoritePrefabs.Count - 1)], meteoritePrefabs[0], randoSpawn);
                temp.GetComponent<Rigidbody>().AddForce(Direction * Speed);
                //SphereCollider col = temp.GetComponentInChildren<SphereCollider>();
                //col.radius = 0.9f;
            }
            timesActivated++;
            Activated = true;
        }
    }
}
