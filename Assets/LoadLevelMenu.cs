using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1()
    {
        if (GameManager.highestLevelReached >= 1)
        {
            SceneManager.LoadScene("Scenes/SampleScene");
        }
    }

    public void Level2()
    {
        if (GameManager.highestLevelReached >= 2)
        {
            SceneManager.LoadScene("Scenes/SampleScene 1");
        }
    }

    public void Level3()
    {
        if (GameManager.highestLevelReached >= 3)
        {
            SceneManager.LoadScene("Scenes/SampleScene 2");
        }
    }

    public void Level4()
    {
        if (GameManager.highestLevelReached >= 4)
        {
            SceneManager.LoadScene("Scenes/SampleScene 3");
        }
    }

    public void Level5()
    {
        if (GameManager.highestLevelReached >= 5)
        {
            SceneManager.LoadScene("Scenes/SampleScene 4");
        }
    }
}
