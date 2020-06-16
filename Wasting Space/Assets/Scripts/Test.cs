using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Test : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;
    Process process = new Process();

    // Start is called before the first frame update
    void Start()
    {
        process.StartInfo.FileName = "tabtip.exe";//Filename
        process.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            process.Kill();
        }
    }
}
