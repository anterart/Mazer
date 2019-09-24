﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {  
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullet");
        foreach (GameObject bullet in bullets)
            GameObject.Destroy(bullet);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullet");
        foreach (GameObject bullet in bullets)
            GameObject.Destroy(bullet);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/MainMenu");
        
    }

    public void Quit()
    {
        Application.Quit();
        
    }
}
