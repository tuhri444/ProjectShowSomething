using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image fillBar;
    [SerializeField] private Image bronze;
    [SerializeField] private Image silver;
    [SerializeField] private Image gold;
    [SerializeField] private PlayerSettings score;
    [SerializeField] private int totalAchievement;

    private int firstAchievement;
    private int secondAchievement;
    private int thirdAchievement;

    void Start()
    {
        firstAchievement = (int)Math.Floor(totalAchievement * 0.25f);
        secondAchievement = (int)Math.Floor(totalAchievement * 0.5f);
        thirdAchievement = (int)Math.Floor(totalAchievement * 0.75f);
        score = FindObjectOfType<PlayerSettings>();
    }

    void Update()
    {
        UpdateSlider();
        ShowMedals();

    }

    private void ShowMedals()
    {
        if(CheckAchievement(firstAchievement))
        {
            var tempColor = bronze.color;
            tempColor.a = Mathf.Lerp(tempColor.a,255,Time.deltaTime*0.01f);
            bronze.color = tempColor;
        }
        if (CheckAchievement(secondAchievement))
        {
            var tempColor = silver.color;
            tempColor.a = Mathf.Lerp(tempColor.a, 255, Time.deltaTime * 0.01f);
            silver.color = tempColor;
        }
        if (CheckAchievement(thirdAchievement))
        {
            var tempColor = gold.color;
            tempColor.a = Mathf.Lerp(tempColor.a, 255, Time.deltaTime * 0.01f);
            gold.color = tempColor;
        }
    }

    private bool CheckAchievement(int amountToCheck)
    {
        if (amountToCheck <= score.JunkCollected) return true;
        return false;
    }

    private void UpdateSlider()
    {
        fillBar.fillAmount = 1.0f / totalAchievement * score.JunkCollected;
    }
}
