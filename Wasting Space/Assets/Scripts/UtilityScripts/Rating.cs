using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rating : MonoBehaviour
{
    int rating = -1;
    public void OnClick()
    {
        if (gameObject.name == "Good")
        {
            rating = 2;
        }
        else if(gameObject.name == "NotBad")
        {
            rating = 1;
        }
        else
        {
            rating = 0;
        }
    }

    public int Ratings
    {
        get { return rating; }
    }
}
