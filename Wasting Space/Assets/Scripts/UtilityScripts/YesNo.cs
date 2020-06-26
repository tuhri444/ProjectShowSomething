using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesNo : MonoBehaviour
{
    [SerializeField]
    List<Sprite> ogImg = new List<Sprite>();

    [SerializeField]
    List<Sprite> iconClicked = new List<Sprite>();   
    
    string hadFun = "";

    public void OnClick(GameObject button)
    {
        transform.GetChild(0).GetComponent<Image>().sprite = ogImg[0];
        transform.GetChild(1).GetComponent<Image>().sprite = ogImg[1];
        if (button.name == "Yes")
        {
            hadFun = "Yes";
            button.GetComponent<Image>().sprite = iconClicked[0];
        }
        else
        {
            hadFun = "No";
            button.GetComponent<Image>().sprite = iconClicked[1];
        }
    }

    public string HadFun
    {
        get { return hadFun; }
    }
}
