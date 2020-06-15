using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFastForward : MonoBehaviour
{
    [SerializeField] private GameObject button;

    private bool showButton;
    private float TimePassed;
    private float Timer = 5.0f;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            showButton = true;
            TimePassed = 0.0f;
        }

        if (showButton)
        {
            if (TimePassed >= Timer)
            {
                TimePassed = 0.0f;
                showButton = false;
            }
            TimePassed += Time.deltaTime;
            if (button.activeSelf == false)
                button.SetActive(true);
        }
        else
        {
            if (button.activeSelf)
                button.SetActive(false);
        }
    }
}
