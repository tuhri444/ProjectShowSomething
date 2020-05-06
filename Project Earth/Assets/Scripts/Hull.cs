using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hull : MonoBehaviour
{
    public int hp = 100;
    public int score = 0;

    void Update()
    {
        if(hp <= 0)
        {
            Application.LoadLevel(3);
        }
    }
}
