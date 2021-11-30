using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toMenuScript : MonoBehaviour
{
    public void toMenu()
    {
        SceneManager.LoadScene("StartingScene");
    }
}
