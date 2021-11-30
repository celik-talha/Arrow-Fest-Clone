using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartLevel : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
}
