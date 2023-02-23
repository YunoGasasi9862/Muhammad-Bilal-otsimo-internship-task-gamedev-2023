using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class SceneManagementGame : MonoBehaviour
{
    private int count = 1;
    [SerializeField] TMPro.TextMeshProUGUI _text;
   
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

    public void Exit()
    {

        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        count++;
        SceneManager.LoadScene("Level" + count);
        LevelName();

    }

    public void LevelName() {

        _text.text = count.ToString("0");
        Debug.Log(count);
    }
}
