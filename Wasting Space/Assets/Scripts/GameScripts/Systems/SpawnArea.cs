using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class SpawnArea : MonoBehaviour
{
    [SerializeField] private float SpawnCap;
    [Range(0.0f, 100.0f)] [SerializeField] private float SatteliteJunkRatio;
    [Range(0.0f, 100.0f)] [SerializeField] private float MaxSpawnVelocity;
    [Range(0.0f, 5.0f)] [SerializeField] private float JunkScaleModifier;
    [Range(0.0f, 5.0f)] [SerializeField] private float SatteliteScaleModifier;

    [SerializeField] private List<GameObject> JunkPrefabs;
    [SerializeField] private List<GameObject> SattelitePrefabs;
    [SerializeField] private GameObject ExplosionPrefab;

    [SerializeField] public Color EditorColor;
    public bool dragging;


    private int SatteliteToSpawn;
    private int JunkToSpawn;

    private float TimePassed;
    private float Timer = 0.2f;
    private bool Timed;

    private List<Junk> Junks;
    private List<Sattelite> Sattelites;
    private Vector2 Size;
    private Vector2 TopLeft;
    private Vector2 BottomRight;

    void Start()
    {
        Junks = new List<Junk>();
        Sattelites = new List<Sattelite>();

        Size = GetComponent<RectTransform>().sizeDelta;
        TopLeft = new Vector2(transform.position.x - Size.x * 0.5f, transform.position.y - Size.y * 0.5f);
        BottomRight = new Vector2(transform.position.x + Size.x * 0.5f, transform.position.y + Size.y * 0.5f);

        SatteliteToSpawn = Mathf.RoundToInt(SpawnCap / 100 * (100.0f - SatteliteJunkRatio));
        JunkToSpawn = Mathf.RoundToInt(SpawnCap / 100 * SatteliteJunkRatio);

        Spawn();

    }

    private void Update()
    {
        if(TimePassed > Timer && !Timed)
        {
            for (int i = 0; i < Sattelites.Count; i++)
            {
                Sattelites[i].GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            }
            for (int i = 0; i < Junks.Count; i++)
            {
                Junks[i].GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            }
            Timed = true;
        }
        if(Timed == false)
            TimePassed += Time.deltaTime;
    }

    private void Spawn()
    {
        Vector3 spawnLocation;
        float scale;
        int randomPrefab;
        Vector3 startVelocity;
        for (int i = 0; i < SatteliteToSpawn; i++)
        {
            spawnLocation = new Vector3(Random.Range(TopLeft.x, BottomRight.x), Random.Range(TopLeft.y, BottomRight.y), 0);

            //bool goodlocation = false;
            //while (goodlocation != true)
            //{
            //    foreach (Junk item in Junks)
            //    {
            //        spawnLocation = new Vector3(Random.Range(TopLeft.x, BottomRight.x), Random.Range(TopLeft.y, BottomRight.y), 0);
            //        goodlocation = CompareSpawnLocation(spawnLocation, item.transform.position);
            //        if (goodlocation) break;
            //    }
            //    foreach (Sattelite item in Sattelites)
            //    {
            //        spawnLocation = new Vector3(Random.Range(TopLeft.x, BottomRight.x), Random.Range(TopLeft.y, BottomRight.y), 0);
            //        goodlocation = CompareSpawnLocation(spawnLocation, item.transform.position);
            //        if (goodlocation) break;
            //    }
            //}

            scale = Random.Range(1, 1 + SatteliteScaleModifier);
            randomPrefab = Random.Range(0, SattelitePrefabs.Count - 1);
            startVelocity = new Vector3(Random.Range(-MaxSpawnVelocity, MaxSpawnVelocity), Random.Range(-MaxSpawnVelocity, MaxSpawnVelocity), 0);

            GameObject temp = Sattelite.CreateSattelite(SattelitePrefabs[randomPrefab], ExplosionPrefab, spawnLocation);
            temp.layer = 10;
            temp.transform.parent = this.transform;
            temp.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            //temp.transform.localScale = new Vector3(scale*0.3f,scale * 0.3f, scale * 0.3f);
            temp.GetComponent<Rigidbody>().velocity = startVelocity;
            temp.GetComponent<Rigidbody>().mass = Random.Range(3, 8);
            Sattelites.Add(temp.GetComponent<Sattelite>());
        }
        for (int i = 0; i < JunkToSpawn; i++)
        {
            spawnLocation = new Vector3(Random.Range(TopLeft.x, BottomRight.x), Random.Range(TopLeft.y, BottomRight.y), 0);

            //bool goodlocation = false;
            //while (goodlocation != true)
            //{
            //    foreach (Junk item in Junks)
            //    {
            //        spawnLocation = new Vector3(Random.Range(TopLeft.x, BottomRight.x), Random.Range(TopLeft.y, BottomRight.y), 0);
            //        goodlocation = CompareSpawnLocation(spawnLocation, item.transform.position);
            //        if (goodlocation) break;
            //    }
            //    foreach (Sattelite item in Sattelites)
            //    {
            //        spawnLocation = new Vector3(Random.Range(TopLeft.x, BottomRight.x), Random.Range(TopLeft.y, BottomRight.y), 0);
            //        goodlocation = CompareSpawnLocation(spawnLocation, item.transform.position);
            //        if (goodlocation) break;
            //    }
            //}

            scale = Random.Range(1 - JunkScaleModifier, 1 + JunkScaleModifier);
            randomPrefab = Random.Range(0, JunkPrefabs.Count - 1);
            startVelocity = new Vector3(Random.Range(-MaxSpawnVelocity, MaxSpawnVelocity), Random.Range(-MaxSpawnVelocity, MaxSpawnVelocity), 0);

            GameObject temp = Junk.CreateJunk(JunkPrefabs[randomPrefab], ExplosionPrefab, spawnLocation,false);
            temp.transform.parent = this.transform;
            temp.transform.localScale = new Vector3(1f, 1f, 1f);
            //temp.transform.localScale = new Vector3(scale, scale, scale);
            temp.GetComponent<Rigidbody>().velocity = startVelocity;
            Junks.Add(temp.GetComponent<Junk>());
        }
    }
#if UNITY_EDITOR
    [DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.InSelectionHierarchy)]
    public static void RenderCustomGizmo(SpawnArea _target, GizmoType _gizmoType)
    {
        SpawnArea myTarget = _target;
        if (myTarget == null)
            return;

        Vector3 center = myTarget.transform.position;
        Vector2 Size = myTarget.GetComponent<RectTransform>().sizeDelta;
        Vector2 topLeft = new Vector2(center.x - Size.x * 0.5f, center.y - Size.y * 0.5f);
        Rect bounds = new Rect(topLeft.x, topLeft.y, Size.x, Size.y);
        Handles.DrawSolidRectangleWithOutline(bounds, myTarget.EditorColor, new Color(0, 0, 0, 1));

        Vector2 mousePos = Event.current.mousePosition;
        mousePos.y = Camera.current.pixelHeight - mousePos.y;
        Vector2 checkPos = Camera.current.ScreenToWorldPoint(mousePos);

        bool inBounds = bounds.Contains(checkPos);

        if (inBounds && Event.current.type == EventType.MouseUp) _target.dragging = false;
        else if (inBounds && Event.current.type == EventType.MouseDown) _target.dragging = true;

        if (_target.dragging)
        {
            myTarget.transform.position = checkPos;
        }
    }
    //Code here for Editor only.
#endif

    private bool CompareSpawnLocation(Vector3 locA, Vector3 locB)
    {
        if(Vector3.Distance(locA,locB) > 1.0f)
        {
            return true;
        }
        return false;
    }
        


}
