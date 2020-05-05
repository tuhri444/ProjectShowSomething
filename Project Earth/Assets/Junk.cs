using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk : MonoBehaviour
{
    // Start is called before the first frame update
    public float scale;
    public int score;

    private void Start()
    {
        scale = Random.Range(0.5f, 1.0f);
        score = (int)(scale * 10.0f);
        transform.localScale = new Vector3(scale,scale,scale);
    }
}
