using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesNo : MonoBehaviour
{
    int hadFun = -1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (gameObject.name == "Yes")
        {
            hadFun = 1;
        }
        else
        {
            hadFun = 0;
        }
    }

    public int HadFun
    {
        get { return hadFun; }
    }
}
