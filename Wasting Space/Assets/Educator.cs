using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class Educator : MonoBehaviour
{
    private GameObject factBubble;
    private List<string> facts = new List<string>();
    private static Animator animator;
    private Text factText;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        factBubble = transform.GetChild(0).gameObject;
        factText = factBubble.GetComponentInChildren<Text>();
        factBubble.SetActive(false);
        facts = InitializeList();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SlideDown()
    {
        animator.SetTrigger("SlideDown");
    }

    public static void SlideUp()
    {
        animator.SetTrigger("SlideUp");
    }

    public void SayFact()
    {
        Debug.Log("Fact");
        factBubble.SetActive(true);
        factText.text = GenerateFact();
    }

    public void StopFact()
    {
        Debug.Log("StopFact");
        factText.text = "";
        factBubble.SetActive(false);
    }


    private List<string> InitializeList()
    {
        try
        {
            TextAsset facts = Resources.Load<TextAsset>(PlayerPrefs.GetString("Language") + "Facts") as TextAsset;
            facts.text.Trim('\n');
            Debug.Log(facts.text);
            string[] split = facts.text.Split(';');
            return split.ToList();
        } 
        catch(Exception e)
        {
            return new List<string>() { "Hello World" };
        }
    }
    private string GenerateFact()
    {
        int randNum = UnityEngine.Random.Range(0,facts.Count);
        return facts[randNum];
    }
}
