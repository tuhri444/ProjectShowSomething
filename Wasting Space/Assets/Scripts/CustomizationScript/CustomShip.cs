using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class CustomShip : MonoBehaviour
{
    //Serializable Fields
    [SerializeField]
    private GameObject[] activeParts = new GameObject[2];

    //Non-Serializable Fields
    private Cycler[] cyclers = new Cycler[3];
    private ShipSettings shipSettings;

    // Start is called before the first frame update
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        //shipSettings = FindObjectOfType<ShipSettings>();
        shipSettings = ShipSettings.Instance;
        for(int i =0;i<transform.childCount;i++)
        {
            cyclers[i] = transform.GetChild(i).GetComponent<Cycler>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        GameObject[] temp = new GameObject[2];
        activeParts[0] = cyclers[0].Part;
        activeParts[1] = cyclers[1].Part;

        //for (int i = 0; i < 3; i++)
        //{
        //    temp[i] = Instantiate(activeParts[i]) as GameObject;
        //}
        shipSettings.Parts = activeParts;
    }
}
