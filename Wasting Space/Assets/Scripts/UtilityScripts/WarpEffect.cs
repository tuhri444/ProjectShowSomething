using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpEffect : MonoBehaviour
{
    //Serializable Fields
    [SerializeField]
    float particleRateMax = 10;

    //Non-Serializable Fields
    ParticleSystem particleSystem;
    ShipMovement shipMovement;
    float currentSpeed;
    Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        shipMovement = FindObjectOfType<ShipMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        velocity = shipMovement.GetComponent<Rigidbody>().velocity;
        currentSpeed = Mathf.Clamp(velocity.magnitude, 0, particleRateMax);

        var emmisionController = particleSystem.emission;
        emmisionController.rateOverTime = currentSpeed / 2f;

        var mainParticleController = particleSystem.main;
        mainParticleController.startSpeed = currentSpeed;

        //var shapeController = particleSystem.shape;
        //Vector3 velNormal = velocity.normalized;
        //float angle = Mathf.Atan2(velNormal.x, velNormal.y) * Mathf.Rad2Deg;
        //shapeController.rotation = new Vector3(0,angle,0);

    }
}
