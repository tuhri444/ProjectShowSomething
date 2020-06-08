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
        for (int i = 0; i < activateObject.Count; i++)
        {
            activateObject[i].SetActive(true);
        }
        for (int i = 0; i < deactivateObject.Count; i++)
        {
            deactivateObject[i].SetActive(false);
        }
    }

}


