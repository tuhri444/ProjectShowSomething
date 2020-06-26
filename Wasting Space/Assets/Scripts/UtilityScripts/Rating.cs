using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rating : MonoBehaviour
{
    [SerializeField]
    List<Sprite> ogImg = new List<Sprite>();

    [SerializeField]
    List<Sprite> clickedIcons = new List<Sprite>(); 
    string rating = "";

    public void OnClick(GameObject button)
    {
        Debug.Log(button.name);
        transform.GetChild(0).GetComponent<Image>().sprite = ogImg[0];
        transform.GetChild(1).GetComponent<Image>().sprite = ogImg[1];
        transform.GetChild(2).GetComponent<Image>().sprite = ogImg[2];
        if (button.name == "Good")
        {
            rating = "Good";
            button.GetComponent<Image>().sprite = clickedIcons[2];
        }
        else if(button.name == "NotBad")
        {
            rating = "Meh";
            button.GetComponent<Image>().sprite = clickedIcons[1];
        }
        else
        {
            rating = "Bad";
            button.GetComponent<Image>().sprite = clickedIcons[0];
        }
    }

    public string Ratings
    {
        get { return rating; }
    }
}
