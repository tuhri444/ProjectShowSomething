using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnEvent();
public struct RadarObject
{
    public GameObject gameObejct;
    public GameObject uiImage;
}
public class Radar : MonoBehaviour
{
    private List<RadarObject> radarObjects = new List<RadarObject>();
    private List<GameObject> objectsOnRadarLayer;
    private List<GameObject> iconsOnRadar = new List<GameObject>();
    public static OnEvent OnRemoveItem;
    public Image panel;

    public void Start()
    {
        objectsOnRadarLayer = GetObjectsInLayer(8);
        panel = GetComponent<Image>();
    }

    public void Update()
    {
       

        foreach (GameObject go in objectsOnRadarLayer)
        {
            if (go.GetComponent<Renderer>() != null)
            {
                Renderer goRenderer = go.GetComponent<Renderer>();
                if (goRenderer.isVisible && IsOnRadarObjects(go))
                {
                    RegisterRadarObject(go);
                    Debug.Log("Registered");
                }
                else if (!goRenderer.isVisible && IsOnRadarObjects(go))
                {
                    RemoveRadarObject(go);
                }
            }
        }

        foreach (RadarObject ro in radarObjects)
        {
            GameObject icon = Instantiate(ro.uiImage,transform);
            Vector3 roPosition = ro.gameObejct.transform.position;
            icon.transform.position = new Vector3(roPosition.x,roPosition.y,roPosition.z);
            iconsOnRadar.Add(icon);
        }

    }

    public void RegisterRadarObject(GameObject _radarObject)
    {
        GameObject icon = new GameObject();
        icon.AddComponent<Image>();
        Image iconImg = icon.GetComponent<Image>();
        if (_radarObject.name.Equals("ship"))
        {
            iconImg.color = new Color(0, 255, 0);
        }
        else
        {
            iconImg.color = new Color(255, 0, 0);
        }
        RadarObject radarObject = new RadarObject()
        {
            gameObejct = _radarObject,
            uiImage = icon
        };
        radarObjects.Add(new RadarObject());
    }

    public void RemoveRadarObject(GameObject _radarObject)
    {
        foreach (RadarObject ro in radarObjects)
        {
            if (ro.gameObejct.Equals(_radarObject))
            {
                OnRemoveItem();
                radarObjects.Remove(ro);
                Destroy(ro.gameObejct);
                Destroy(ro.uiImage);
                return;
            }
        }
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

    private bool IsOnRadarObjects(GameObject go)
    {
        foreach (RadarObject ro in radarObjects)
        {
            if (ro.gameObejct.Equals(go))
            {
                return true;
            }
        }
        return false;
    }

}
