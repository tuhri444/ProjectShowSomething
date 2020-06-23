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
    int rating = -1;

    public void OnClick(GameObject button)
    {
        Debug.Log(button.name);
        transform.GetChild(0).GetComponent<Image>().sprite = ogImg[0];
        transform.GetChild(1).GetComponent<Image>().sprite = ogImg[1];
        transform.GetChild(2).GetComponent<Image>().sprite = ogImg[2];
        if (button.name == "Good")
        {
            rating = 2;
            button.GetComponent<Image>().sprite = clickedIcons[2];
        }
        else if(button.name == "NotBad")
        {
            rating = 1;
            button.GetComponent<Image>().sprite = clickedIcons[1];
        }
        else
        {
            rating = 0;
            button.GetComponent<Image>().sprite = clickedIcons[0];
        }
    }

    public int Ratings
    {
        get { return rating; }
    }
}
