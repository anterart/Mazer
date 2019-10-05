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
        text.text = "Welcome! \n In this tutorial you will learn some basics needed in order to be a true MAZE FIGHTER! \n Touch the jotstick located on the bottom left of your screen to move!";
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
                text.text = "Good! \n From now on use this joystick to move in the game. \n Now try to use your gun to shoot. \n Touch your screen in the direction you want to shoot now.";
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
                    text.text = "Excellent! \n Now look, there is an enemy in the center of the map! \n He is not moving but will shoot you if you get too close, so be careful! \n Shoot him several times to Kill him and take the flag he carries! \n The colored arrow points you to the direction you need to go if your destination is not currently present on the screen.";
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
                    text.text = "Very good! \n In the real game enemies will run and shoot at you. \n You and your enemies will respawn at random locations on the map after death. \n Your mission is to capture the flag and reach the yellow portal first. \n If one captures the flag, he will be marked with flag sign above his head. \n If one has the flag and die, the flag will be dropped at the same spot where the death has occured. \n Remember to use the colored arrow to ease your navigation around the map. \n Now, proceed to the yellow portal to finish this tutorial and begin your advanture! \n Good luck!";
                }
            }
        }
    }
}
