using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class startingScreen : MonoBehaviour
{
    public Text levelText;
    public int currentLevel;

    void Start()
    {
        PlayerPrefs.SetInt("currLevel", 1);
        currentLevel = PlayerPrefs.GetInt("currLevel");
        levelText.text = "Continue From Level " + currentLevel;
        
    }


}
