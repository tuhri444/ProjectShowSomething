using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotationStat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Booster booster = FindObjectOfType<Booster>();
        GetComponent<Image>().fillAmount = (booster.AngularAcceleration) / 25;
    }
}
