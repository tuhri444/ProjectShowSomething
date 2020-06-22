using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KeyboardInput : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_InputField input;
    void Start()
    {
        input = GameObject.Find("NameInput").GetComponent<TMP_InputField>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeyPressed()
    {
        switch (gameObject.name)
        {
            case "Delete":
                Delete();
                break;
            case "Space":
                Space();
                break;
            default:
                EnteredKey(gameObject.name);
                break;
        }

    }

    void Delete()
    {
        string inputString = input.text;
        if (inputString.Length > 0)
        {
            input.text = inputString.Substring(0, inputString.Length - 1);
        }
    }

    void Space()
    {
        input.text += " ";
    }

    void EnteredKey(string key)
    {
        if (input.text.Length < 7)
        {
            input.text += key;
        }
    }
}
