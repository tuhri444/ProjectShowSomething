using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnArea : MonoBehaviour
{
    [SerializeField] private float SpawnCap;
    [Range(0.0f,100.0f)][SerializeField] private float JunkSatteliteRatio;
    [Range(0.0f, 100.0f)] [SerializeField] private float MaxSpawnVelocity;
    [Range(0.0f, 5.0f)] [SerializeField] private float JunkScaleModifier;
    [Range(0.0f, 5.0f)] [SerializeField] private float SatteliteScaleModifier;

    [SerializeField] private List<GameObject> JunkPrefabs;
    [SerializeField] private List<GameObject> SattelitePrefabs;
    [SerializeField] private ParticleSystem ExplosionPrefab;

    private int SatteliteToSpawn;
    private int JunkToSpawn;
    
    private List<Junk> Junks;
    private List<Sattelite> Sattelites;
    private Vector2 Size;
    private Vector2 TopLeft;
    private Vector2 BottomRight;

    void Start()
    {
        Size = GetComponent<RectTransform>().sizeDelta;
        TopLeft = new Vector2(transform.position.x - Size.x * 0.5f, transform.position.y - Size.y * 0.5f);
        BottomRight = new Vector2(transform.position.x + Size.x * 0.5f, transform.position.y + Size.y * 0.5f);

        SatteliteToSpawn = Mathf.RoundToInt(SpawnCap /100*(100.0f - JunkSatteliteRatio));
        JunkToSpawn = Mathf.RoundToInt(SpawnCap /100*JunkSatteliteRatio);

        Spawn();
    }

    private void Spawn()
    {
        Vector3 spawnLocation;
        float scale;
        int randomPrefab;
        for (int i = 0; i < SatteliteToSpawn; i++)
        {
            spawnLocation = new Vector3(Random.Range(TopLeft.x, BottomRight.x), Random.Range(TopLeft.y, BottomRight.y), 0);
            scale = Random.Range(1 - SatteliteScaleModifier, 1 + SatteliteScaleModifier);
            randomPrefab = Random.Range(0, SattelitePrefabs.Count - 1);
            GameObject temp = Sattelite.CreateSattelite(SattelitePrefabs[randomPrefab], ExplosionPrefab, spawnLocation);
            temp.transform.localScale = new Vector3(scale,scale,scale);
            Sattelites.Add(temp.GetComponent<Sattelite>());
        }
        for (int i = 0; i < JunkToSpawn; i++)
        {
            spawnLocation = new Vector3(Random.Range(TopLeft.x, BottomRight.x), Random.Range(TopLeft.y, BottomRight.y), 0);
            scale = Random.Range(1 - JunkScaleModifier, 1 + JunkScaleModifier);
            randomPrefab = Random.Range(0, JunkPrefabs.Count - 1);
            GameObject temp = Junk.CreateJunk(JunkPrefabs[randomPrefab], ExplosionPrefab, spawnLocation,false);
            temp.transform.localScale = new Vector3(scale, scale, scale);
            Junks.Add(temp.GetComponent<Junk>());
        }
    }

}
