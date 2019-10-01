using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static int highestLevelReached;
    public static int highetSceneReached;

    public void Awake()
    {
        highestLevelReached = PlayerPrefs.GetInt("HIGHEST_LEVEL", 1);
        highetSceneReached = PlayerPrefs.GetInt("HIGHEST_SCENE", 1);
    }
    public void newGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void TutorialLunch()
    {
        SceneManager.LoadScene("Scenes/TutorialScene");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
