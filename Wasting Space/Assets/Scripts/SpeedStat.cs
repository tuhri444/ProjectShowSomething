using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedStat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Booster booster = FindObjectOfType<Booster>();
        GetComponent<Image>().fillAmount = (booster.Acceleration+booster.AngularAcceleration) / 35;
    }
}
