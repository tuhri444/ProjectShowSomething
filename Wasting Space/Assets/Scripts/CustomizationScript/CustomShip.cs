using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class CustomShip : MonoBehaviour
{
    //Serializable Fields
    [SerializeField]
    private GameObject[] activeParts = new GameObject[3];

    //Non-Serializable Fields
    private Cycler[] cyclers = new Cycler[3];

    // Start is called before the first frame update
    private void Start()
    {
        for(int i =0;i<transform.childCount;i++)
        {
            cyclers[i] = transform.GetChild(i).GetComponent<Cycler>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerPrefs.SetString("ActiveGrabber", cyclers[0].Part.name);
        PlayerPrefs.SetString("ActiveHull",cyclers[1].Part.name);
        PlayerPrefs.SetString("ActiveBooster", cyclers[2].Part.name);
    }
}
