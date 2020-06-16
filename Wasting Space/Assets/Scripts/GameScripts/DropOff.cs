using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour
{
    [SerializeField] private float MoveIntoPlaceSpeed;
    [SerializeField] private float RotateIntoPlaceSpeed;

    private PlayerSettings playerSettings;
    private Hull hull;
    private Ship ship;
    private ShipMovement movement;
    private bool isDropping;

    private bool lockIn;
    public bool GetLockIn { get => lockIn;}
    public void LockIn()
    {
        lockIn = true;
    }
    public void Decouple()
    {
        lockIn = false;
        ship.GetComponent<Rigidbody>().AddForce(Vector3.up * 10.0f, ForceMode.Impulse);
    }

    void Start()
    {
        playerSettings = FindObjectOfType<PlayerSettings>();
        hull = FindObjectOfType<Hull>();
        ship = FindObjectOfType<Ship>();
        movement = FindObjectOfType<ShipMovement>();
    }

    void Update()
    {

    }

    public void Trigger(Collider other)
    {
        if (lockIn)
        {
            Vector3 DesiredPosition = transform.position;
            DesiredPosition.z = 0;
            ship.transform.position = Vector3.Lerp(ship.transform.position, DesiredPosition, Time.deltaTime * MoveIntoPlaceSpeed);
            movement.EnableMovement = false;
            ship.transform.rotation = Quaternion.Lerp(ship.transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0)), Time.deltaTime * RotateIntoPlaceSpeed);
            if (!isDropping && Approximate(DesiredPosition,ship.transform.position) && playerSettings.InternalJunkCollected >= 1.0f)
                StartCoroutine(Countdown());
        }
        else
        {
            movement.EnableMovement = true;
        }
    }

    private IEnumerator Countdown()
    {
        isDropping = true;
        float duration = 0.2f;
        float normalizedTime = 0;
        while (normalizedTime <= 1.0f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        if (playerSettings.InternalJunkCollected >= 1)
        {
            playerSettings.InternalJunkCollected -= 1;
            playerSettings.JunkCollected += 1;
        }
        isDropping = false;
    }

    private bool Approximate(Vector3 a, Vector3 b)
    {
        float distance = Vector3.Distance(a, b);
        if(distance < 0.1f)
        {
            return true;
        }
        return false;
    }
}
