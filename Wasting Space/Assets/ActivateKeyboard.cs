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
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        canvas = GameObject.Find("InGame_UI");

        keyboardRes = Resources.Load("Keyboard") as GameObject;
        keyboard = Instantiate(keyboardRes,canvas.transform);
        keyboard.SetActive(false);

        endMenu = GameObject.Find("EndMenu(Clone)");
        endMenu.transform.localPosition = new Vector3(0, endMenu.transform.localPosition.y, 0);

    }

    // Update is called once per frame
    void Update()
    {
        endMenu.transform.DOLocalMove(endPos, 1);
    }

    public void OnSelect()
    {
        keyboard.SetActive(true);
        endPos = new Vector3(0, 200, 0);
    }

    public void OnDeselect()
    {
        keyboard.SetActive(false);
        endPos = new Vector3(0, 0, 0);
    }
}
