using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
    // Detects manually if obj is being seen by the main camera

    //Serializable Fields
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject radarSprite;

    //Non-Serializable Fields
    private Plane[] planes;
    private List<GameObject> radarObjects = new List<GameObject>();
    private Dictionary<GameObject, RawImage> radarUI = new Dictionary<GameObject, RawImage>();
    private Dictionary<GameObject,RawImage> toBeDestroyed = new Dictionary<GameObject,RawImage>();


    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        toBeDestroyed.Clear();
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("RadarObject"))
        {
            if (GeometryUtility.TestPlanesAABB(planes, go.GetComponent<Collider>().bounds))
            {
                if (!radarObjects.Contains(go))
                {
                    radarObjects.Add(go);
                }
            }
        }
        foreach (GameObject go in radarObjects)
        {
            if (go != null)
            {
                if (radarUI.ContainsKey(go))
                {
                    radarUI[go].rectTransform.position = new Vector3(go.transform.position.x, go.transform.position.y, -1);
                }
                else
                {
                    GameObject image = Instantiate(radarSprite, canvas.transform);
                    image.layer = 8;
                    Vector3 uiPos = go.transform.localPosition;
                    radarUI[go] = image.GetComponent<RawImage>();
                    radarUI[go].rectTransform.position = new Vector3(uiPos.x, uiPos.y, -1);

                    if (go.GetComponent<Ship>() != null)
                    {
                        radarUI[go].color = new Color(0, 255, 0);
                        continue;
                    }

                    if (go.GetComponent<Junk>() != null) 
                    {
                        radarUI[go].color = new Color(0, 0, 255);
                        continue;
                    }
                    
                    if(go.GetComponent<Sattelite>() != null)
                    {
                        radarUI[go].color = new Color(255, 0, 0);
                        continue;
                    }
                }
            } 
            else
            {
                Debug.Log("Removed");
                radarUI[go].enabled = false;
            }
        }
    }
}

