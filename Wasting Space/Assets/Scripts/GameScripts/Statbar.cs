using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Statbar : MonoBehaviour
{
    //Serializable Fields
    [SerializeField]
    private GameObject valueSource;

    //Non-Serializable Fields
    private Image bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (valueSource.name.Contains("Body"))
        {
            if (name.Contains("CapacityBar"))
            {
                for (int i = 0; i < valueSource.transform.childCount; i++)
                {
                    if (valueSource.transform.GetChild(i).gameObject.activeSelf)
                        bar.fillAmount = valueSource.transform.GetChild(i).GetComponent<Hull>().Capacity / 50.0f;
                }
            }
            if (name.Contains("HealthBar"))
            {
                for (int i = 0; i < valueSource.transform.childCount; i++)
                {
                    if (valueSource.transform.GetChild(i).gameObject.activeSelf)
                        bar.fillAmount = valueSource.transform.GetChild(i).GetComponent<Hull>().Health / 100.0f;
                }
            }
        }
        if (valueSource.name.Contains("Booster"))
        {
            if (name.Contains("AccelBar"))
            {
                for (int i = 0; i < valueSource.transform.childCount; i++)
                {
                    if (valueSource.transform.GetChild(i).gameObject.activeSelf)
                        bar.fillAmount = valueSource.transform.GetChild(i).GetComponent<Booster>().Acceleration / 20.0f;
                }
            }
            if (name.Contains("AngAccelBar"))
            {
                for (int i = 0; i < valueSource.transform.childCount; i++)
                {
                    if (valueSource.transform.GetChild(i).gameObject.activeSelf)
                        bar.fillAmount = valueSource.transform.GetChild(i).GetComponent<Booster>().AngularAcceleration / 20.0f;
                }
            }
        }
    }
}
