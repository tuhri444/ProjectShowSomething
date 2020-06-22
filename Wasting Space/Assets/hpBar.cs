using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{
    private Ship ship;
    private bool GoingUp;
    private Image capFill;

    void Start()
    {
        ship = FindObjectOfType<Ship>();
        capFill = GetComponent<Image>();
    }

    void Update()
    {
        if (ship.GetHealth() <= 20.0f)
        {
            if (GoingUp)
            {
                if (capFill.color.a >= 0.99f) GoingUp = false;
                Color fill = capFill.color;
                fill.a = Mathf.Lerp(capFill.color.a, 1, Time.deltaTime * 10.0f);
                capFill.color = fill;
            }
            else
            {
                if (capFill.color.a <= 0.01f) GoingUp = true;
                Color fill = capFill.color;
                fill.a = Mathf.Lerp(capFill.color.a, 0, Time.deltaTime * 10.0f);
                capFill.color = fill;
            }
        }
    }
}
