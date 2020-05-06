using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hull : MonoBehaviour
{
    public int maxHp = 100;
    public int hp;
    public int capacity = 10;
    public int junkCollected = 0;

    void Start()
    {
        hp = maxHp;
    }
    void Update()
    {
        if(hp <= 0)
        {
            Application.LoadLevel(3);
        }
    }
}
