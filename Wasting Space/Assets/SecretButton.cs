using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretButton : MonoBehaviour
{
    public void OnClick()
    {
        Sheets.ClearRequest();
    }
}
