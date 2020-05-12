using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateScore : MonoBehaviour
{
    // Start is called before the first frame update
    private Text txt;
    [SerializeField] DropOff satellite;
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Junk Dropped-off: " + satellite.TotalJunkDroppedOff;
    }

    public int Score
    {
        get { return satellite.TotalJunkDroppedOff; }
    }

}
