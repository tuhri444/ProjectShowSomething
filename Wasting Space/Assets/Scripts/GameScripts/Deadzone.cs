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

}
