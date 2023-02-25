using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneManagementGame : MonoBehaviour
{
    public static int count = 1;
   private TextMeshProUGUI _text;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name != "Complete" && SceneManager.GetActiveScene().name !="MainMenu" && SceneManager.GetActiveScene().name!="Guide")
        {
            _text = GameObject.FindGameObjectWithTag("LevelNUM").GetComponent<TextMeshProUGUI>();
            LevelName();
        }
            
    }
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
        if(SceneManager.GetActiveScene().name=="Level4")
        {
            SceneManager.LoadScene("Complete");
        }
        else
        {
            SceneManager.LoadScene("Level" + count);
            LevelName();
        }
     

    }

    public void LevelName() {

        _text.text = count.ToString("0");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        count = 1;
    }
}
