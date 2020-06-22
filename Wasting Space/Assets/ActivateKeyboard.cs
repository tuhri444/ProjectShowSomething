using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ActivateKeyboard : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject camera;

    private GameObject keyboardRes;
    private GameObject keyboard;
    private GameObject endMenu;

    private Vector3 endPos;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        canvas = GameObject.Find("InGame_UI");

        keyboardRes = Resources.Load("Keyboard") as GameObject;
        keyboard = Instantiate(keyboardRes,canvas.transform);
        keyboard.SetActive(false);

        endMenu = GameObject.Find("EndMenu(Clone)");

        startPos = endMenu.transform.position;
        endPos = endMenu.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        endMenu.transform.DOMove(endPos, 1);
        Debug.Log("MovingMenu");
    }

    public void OnSelect()
    {
        keyboard.SetActive(true);
        startPos = endMenu.transform.position;
        endPos = startPos + new Vector3(0,.7f,0);
    }

    public void OnDeselect()
    {
        keyboard.SetActive(false);
        startPos = endMenu.transform.position;
        endPos = startPos - new Vector3(0, .7f, 0);
    }
}
