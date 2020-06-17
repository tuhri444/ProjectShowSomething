using UnityEngine;
using System.Collections.Generic;

public class SwapActivateObjectScript : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> activateObject;
    [SerializeField]
    private List<GameObject> deactivateObject;

    public void SwapActiveObject()
    {
        deactivateObject.ForEach((GameObject obj) => obj.SetActive(false));
        activateObject.ForEach((GameObject obj) => obj.SetActive(true));
    }
}