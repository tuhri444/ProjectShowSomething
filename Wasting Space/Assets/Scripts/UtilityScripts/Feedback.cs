﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Feedback : MonoBehaviour
{

    public void OnClick()
    {
        Rating rating = FindObjectOfType<Rating>();
        YesNo yesno = FindObjectOfType<YesNo>();
        PlayerPrefs.SetString(PlayerPrefs.GetString("CurrentPlayer"),rating.Ratings+","+yesno.HadFun);

        SceneManager.LoadScene(0);
    }
}
