using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timeout : MonoBehaviour
{
    private Joystick joystick;
    private bool joyStickMoving = false;
    private bool wasdMoving = false;
    private bool clickedOn = false;

    [SerializeField] private float TimePassed;
    private float TimerAmount = 35.0f;
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    void Update()
    {
        if(joystick!=null)
            CheckJoystick();
        CheckKeyboard();

        if(!AnyInput())
        {
            if(TimePassed >= TimerAmount)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                TimePassed += Time.deltaTime;
            }
        }
        else
        {
            TimePassed = 0.0f;
        }

        clickedOn = false;
    }

    private bool AnyInput()
    {
        if (joyStickMoving) return true;
        else if (wasdMoving) return true;
        else if (clickedOn) return true;
        else return false;
    }
    private void CheckJoystick()
    {
        if (joystick.Vertical != 0) joyStickMoving = true;
        else if (joystick.Horizontal != 0) joyStickMoving = true;
        else
        {
            joyStickMoving = false;
        }
    }
    private void CheckKeyboard()
    {
        if (Input.GetKey(KeyCode.W)) wasdMoving = true;
        else if (Input.GetKey(KeyCode.A)) wasdMoving = true;
        else if (Input.GetKey(KeyCode.S)) wasdMoving = true;
        else if (Input.GetKey(KeyCode.D)) wasdMoving = true;
        else wasdMoving = false;
    }
    public void OnClick()
    {
        clickedOn = true;
    }
}
