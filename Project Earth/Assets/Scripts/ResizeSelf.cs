using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

public class ResizeSelf : MonoBehaviour
{
    [SerializeField] Hull playerHull;
    float desiredWidth;
    Image rect;
    [SerializeField] bool Hp;
    void Start()
    {
        rect = GetComponent<Image>();
    }

    void Update()
    {
        if (Hp)
            desiredWidth = 1.0f / playerHull.maxHp * playerHull.hp;
        else
            desiredWidth = 1.0f-(1.0f / playerHull.capacity * playerHull.junkCollected);

        rect.fillAmount = desiredWidth;
    }
}
