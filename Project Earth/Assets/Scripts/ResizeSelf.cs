using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

public class ResizeSelf : MonoBehaviour
{
    [SerializeField] Hull playerHull;
    float TotalWidth;
    float desiredWidth;
    RectTransform rect;
    private Text txt;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        TotalWidth = rect.sizeDelta.x;
        txt = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        desiredWidth = TotalWidth / 100 * playerHull.hp;
        rect.sizeDelta = new Vector2(desiredWidth, rect.sizeDelta.y);
        txt.text = playerHull.hp + "%";
    }
}
