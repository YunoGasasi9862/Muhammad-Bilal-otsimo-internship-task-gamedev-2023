using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementGame : MonoBehaviour
{
    public void LoadGuide()
    {
        SceneManager.LoadScene("Guide");
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");


    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");


    }
}
