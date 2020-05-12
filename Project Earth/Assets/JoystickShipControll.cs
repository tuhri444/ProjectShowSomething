using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickShipControll : MonoBehaviour
{
    [SerializeField] private Shootup movementScript;
    private FixedJoystick joystick;
    float HorAxis;
    float VertAxis;

    void Start()
    {
        joystick = GetComponent<FixedJoystick>();
    }

    void Update()
    {
        movementScript.JoystickForBack(joystick.Vertical);
        movementScript.JoystickLeftRight(joystick.Horizontal);
    }
}
