using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TutorialTextScript : MonoBehaviour
{
    public Text text;
    public bool joysticTouched = false;
    public bool shotsFired = false;
    public bool flagTaken = false;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Welcome! In this tutorial you will learn some basics needed in order to be a true maze fighter! Touch the buttom left jotstick to begin!";
    }

    // Update is called once per frame
    void Update()
    {
        if (!joysticTouched)
        {
            if (Math.Abs(GameObject.Find("Player1").GetComponent<HumanPlayer>().joystick.Horizontal) >= .2f || Math.Abs(GameObject.Find("Player1").GetComponent<HumanPlayer>().joystick.Vertical) >= .2f)
            {
                joysticTouched = true;
            }
            if (joysticTouched)
            {
                text.text = "Good! As you can see, you will use this joystick to move in the game. You can fire at position by pressing it's location on the ground, try this now!";
            }
        }
        if (joysticTouched)
        {
            if (!shotsFired)
            {
                if (GameObject.FindGameObjectsWithTag("bullet").Length >= 1 && GameObject.Find("Player1").GetComponent<HumanPlayer>().hasFired)
                {
                    shotsFired = true;
                }
                if (shotsFired)
                {
                    text.text = "Excellent! Now look, there is an enemy in the center of the map! He is not moving but will shoot you if you get close, so be careful! Shoot him several times to Kill him and take the flag he carries! The colored arrow will point you with the right direction to go, if your destination is not currently present on the screen.";
                }
            }
        }
        if (joysticTouched && shotsFired)
        {
            if (!flagTaken)
            {
                if (GameObject.Find("Player1").GetComponent<HumanPlayer>().isFlagPicked)
                {
                    flagTaken = true;
                }
                if (flagTaken)
                {
                    text.text = "Very good! In the real game, enemies will run and shoot you from greater distances and will respawn at random locations on map after death. Try to take the flag first, kill enemies, don't die yourself and find a yellow portal once you have the flag. If an enemy has the flag, he will be marked with flag sign above him, as you are now and you will have to kill him to obtain it, before he reaches the exit portal. Use the arrow to navigate to your target. Now, proceed to the yellow portal to finish this tutorial!";
                }
            }
        }
    }
}
