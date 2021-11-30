using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class continueButton : MonoBehaviour
{
    public void continueLevel()
    {
        SceneManager.LoadScene("Level " + PlayerPrefs.GetInt("currLevel"));
    }
}
