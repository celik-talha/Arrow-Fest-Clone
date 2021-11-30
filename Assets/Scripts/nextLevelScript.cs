using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevelScript : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("StartingScene");
    }
}
