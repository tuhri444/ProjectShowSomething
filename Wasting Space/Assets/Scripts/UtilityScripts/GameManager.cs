using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameManager : MonoBehaviour
{
    [SerializeField] public List<SpawnArea> SpawnAreas;
    public GameObject SpawnAreaPrefab;

    [SerializeField] private GameObject Ship;
    [SerializeField] private GameObject Radar;
    [SerializeField] public EventSystem EventSystem;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
