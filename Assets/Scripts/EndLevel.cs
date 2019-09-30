using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public int levelToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.GetComponent<Player>().isFlagPicked)
        {
            if (other.GetComponent<Player>().isHuman)
            {
                if (SceneManager.GetActiveScene().buildIndex == MainMenu.highetSceneReached)
                {
                    MainMenu.highetSceneReached += 3;
                    MainMenu.highestLevelReached += 1;
                    PlayerPrefs.SetInt("HIGHEST_LEVEL", MainMenu.highestLevelReached);
                    PlayerPrefs.SetInt("HIGHEST_SCENE", MainMenu.highetSceneReached);
                }
                // load level success scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
            else
            {
                // load level fail scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
