using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarObject : MonoBehaviour
{
    public int id = -1;
    public void Update()
    {
        if(GetComponent<MeshRenderer>().isVisible && id > 0)
        {
            Vector3 shipPosition = Radar.currentPos;
            Vector3 position = gameObject.transform.position;
            Vector3 distanceVec = position-shipPosition;
            Radar.UpdatePosition(id,distanceVec);
        }
    }
    private void OnBecameVisible()
    {
        if (id < 0)
        {
            id = Radar.RegisterRadarObject(gameObject);
        }
        else
        {
            Radar.ReEnableRadarObject(id);
        }
    }

    private void OnBecameInvisible()
    {
        if (id > 0)
        {
            Radar.RemoveRadarObject(id, this.gameObject);
        }
    }
}
