using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnEvent();
public class Radar : MonoBehaviour
{
    public static Dictionary<int, GameObject> radarObjects = new Dictionary<int, GameObject>();
    private static List<GameObject> objectsOnRadarLayer;
    public static OnEvent OnRemoveItem;
    public static Image panel;
    private static int index = 0;
    [SerializeField]
    public static float mapScale = 10;
    public static Vector3 currentPos;
    public static int shipId = 0;

    public void Start()
    {
        objectsOnRadarLayer = GetObjectsInLayer(8);
        panel = GetComponent<Image>();
        foreach (GameObject go in objectsOnRadarLayer)
        {
            go.AddComponent<RadarObject>();
        }
    }
    public void Update()
    {
        Transform ship = GameObject.Find("ship").transform;
        currentPos = ship.position;
    }

    public static int RegisterRadarObject(GameObject _radarObject)
    {
        GameObject icon = new GameObject();
        icon.AddComponent<Image>();
        Image iconImg = icon.GetComponent<Image>();
        icon.transform.SetParent(panel.transform);
        //Mathf.Clamp(roPosition.x, -panel.rectTransform.sizeDelta.x/2f, panel.rectTransform.sizeDelta.x/2f),Mathf.Clamp(roPosition.z, -panel.rectTransform.sizeDelta.y/2f, panel.rectTransform.sizeDelta.y/2f),1
        if (_radarObject.name.Equals("Body"))
        {
            Vector3 roPosition = _radarObject.transform.parent.position;
            iconImg.rectTransform.localPosition = new Vector3(0,0,0);
            iconImg.rectTransform.sizeDelta = new Vector2(10, 10);
            iconImg.color = new Color(0, 255, 0);
        }
        else
        {
            //Mathf.Clamp(_radarObject.transform.position.x, -panel.rectTransform.sizeDelta.x / 2f, panel.rectTransform.sizeDelta.x / 2f), 1, Mathf.Clamp(_radarObject.transform.position.z, -panel.rectTransform.sizeDelta.y / 2f, panel.rectTransform.sizeDelta.y / 2f)
            Vector3 roPosition = new Vector3(_radarObject.transform.position.x,0,_radarObject.transform.position.z);
            iconImg.rectTransform.localPosition = new Vector3(roPosition.x, roPosition.z, 1);
            iconImg.rectTransform.sizeDelta = new Vector2(10, 10);
            iconImg.color = new Color(255, 0, 0);
        }
        radarObjects.Add(++index, icon);
        return index;
    }

    public static void RemoveRadarObject(int id, GameObject _radarObject)
    {
        //Debug.Log("id:" + id);
        //Debug.Log("index:" + index);
        //Debug.Log("Count:" + radarObjects.Count);
        if (radarObjects[id].Equals(_radarObject))
        {
            Destroy(radarObjects[id]);
            radarObjects.Remove(id);
            return;
        }
    }
    public static void ReEnableRadarObject(int id)
    {
        radarObjects[id].SetActive(true);
    }

    private static List<GameObject> GetObjectsInLayer(int layer)
    {
        var goArray = FindObjectsOfType<GameObject>();
        List<GameObject> outList = new List<GameObject>();
        foreach (GameObject go in goArray)
        {
            if (go.layer == layer)
            {
                outList.Add(go);
            }
        }
        return outList;
    }

    public static void UpdatePosition(int id, Vector3 distanceFromOrigin)
    {
        if (id < index && id > 0)
        {
            radarObjects[id].GetComponent<Image>().rectTransform.localPosition = new Vector3(distanceFromOrigin.x*mapScale, distanceFromOrigin.z*mapScale, 1);
        }
    }

}
