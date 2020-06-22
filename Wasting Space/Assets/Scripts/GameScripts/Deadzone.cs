using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    private DeadzoneEffect effect;

    private void Start()
    {
        effect = FindObjectOfType<DeadzoneEffect>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponentInParent<Ship>())
        {
            if (!effect.GetEffectOn())
            {
                effect.TurnEffectOn();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Ship>())
        {
            if (effect.GetEffectOn())
            {
                effect.TurnEffectOff();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("RadarObject"))
        {
            Vector3 direction = (FindObjectOfType<DropOff>().transform.position - other.transform.position).normalized;
            other.GetComponent<Rigidbody>().velocity += direction * 2.0f * Time.deltaTime;
        }
    }

}
