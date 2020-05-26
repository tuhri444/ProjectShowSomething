using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour
{
    private void OnDestroy()
    {
        PlayerSettings pSettings = FindObjectOfType<PlayerSettings>();
        PlayerPrefs.SetInt(PlayerPrefs.GetString("CurrentPlayer"),(int)pSettings.JunkCollected);
    }
}
