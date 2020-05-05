using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperateArrows : MonoBehaviour
{

    [SerializeField] private Texture2D offArrow;
    [SerializeField] private Texture2D onArrow;
    [SerializeField] private List<RawImage> arrows;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            arrows[0].texture = onArrow;
        }
        else
        {
            arrows[0].texture = offArrow;
        }
        if (Input.GetKey(KeyCode.W))
        {
            arrows[1].texture = onArrow;
        }
        else
        {
            arrows[1].texture = offArrow;
        }
        if (Input.GetKey(KeyCode.D))
        {
            arrows[2].texture = onArrow;
        }
        else
        {
            arrows[2].texture = offArrow;
        }
        //if (Input.GetKey(KeyCode.S))
        //{
        //    arrows[3].texture = onArrow;
        //}
        //else
        //{
        //    arrows[3].texture = offArrow;
        //}
    }
}
