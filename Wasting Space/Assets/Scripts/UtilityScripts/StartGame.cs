using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField nameInput;

    public void OnClick()
    {
        if (nameInput.text.Length > 0)
        {
            PlayerPrefs.SetString("CurrentPlayer",nameInput.text);
            SceneManager.LoadScene(1);
        }
    }
}
