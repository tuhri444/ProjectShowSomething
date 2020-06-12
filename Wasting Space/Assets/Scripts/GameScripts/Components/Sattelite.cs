using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sattelite : MonoBehaviour
{
    private List<GameObject> BabyJunk;
    private GameObject Explosion;

    /// <summary>
    /// Creates and returns a sattelite, just plop in a sattelite prefab, add explosion and position. TADA ye got urself a sattelite.
    /// </summary>
    /// <param name="_sattelitePrefab"></param>
    /// <param name="_explosionEffect"></param>
    /// <param name="_position"></param>
    /// <returns></returns>
    public static GameObject CreateSattelite(GameObject _sattelitePrefab, GameObject _explosionEffect, Vector3 _position)
    {
        GameObject satteliteObject = Instantiate(_sattelitePrefab, _position, Quaternion.Euler(0, 0, 0));

        Sattelite sattelite = satteliteObject.AddComponent<Sattelite>() as Sattelite;
        Rigidbody rigidbody = satteliteObject.AddComponent<Rigidbody>() as Rigidbody;
        satteliteObject.AddComponent<SphereCollider>();
        satteliteObject.layer = 10;

        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
        sattelite.Explosion = _explosionEffect;

        sattelite.gameObject.tag = "RadarObject";
        if(satteliteObject.GetComponent<MeshRenderer>()) satteliteObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        else if (satteliteObject.GetComponentInChildren<MeshRenderer>()) satteliteObject.GetComponentInChildren<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        return satteliteObject;
    }
    //TODO
    public void Explode()
    {

    }

}
