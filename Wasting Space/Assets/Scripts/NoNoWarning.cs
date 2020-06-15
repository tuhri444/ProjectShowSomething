using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoNoWarning : MonoBehaviour
{
    [SerializeField]
    private GameObject nonoWarning;
    // Start is called before the first frame update
    void Start()
    {
        nonoWarning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate(bool trualse)
    {
        nonoWarning.SetActive(trualse);
    }
}
