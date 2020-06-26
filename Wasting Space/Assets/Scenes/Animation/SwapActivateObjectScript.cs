using UnityEngine;
using System.Collections.Generic;

public class SwapActivateObjectScript : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> activateObject;
    [SerializeField]
    private List<GameObject> deactivateObject;


    private void Start()
    {
        if(gameObject.name.Contains(PlayerPrefs.GetString("Language")))
        {
            SwapActiveObject();
        }
    }
    public void SwapActiveObject()
    {
        deactivateObject.ForEach((GameObject obj) => obj.SetActive(false));
        activateObject.ForEach((GameObject obj) => obj.SetActive(true));
    }
}