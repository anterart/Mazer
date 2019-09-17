using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    GameObject door1;
    GameObject door2;
    GameObject door3;
    GameObject door4;
    public static bool doorOpened = false;
    public static int doorNumber;
    System.Random random = new System.Random();
    public int levelToLoad;

    private void Start()
    {
        door1 = GameObject.Find("Door1");
        door2 = GameObject.Find("Door2");
        door3 = GameObject.Find("Door3");
        door4 = GameObject.Find("Door4");
        door1.GetComponent<Renderer>().enabled = false;
        door2.GetComponent<Renderer>().enabled = false;
        door3.GetComponent<Renderer>().enabled = false;
        door4.GetComponent<Renderer>().enabled = false;
    }
    void Update()
    {
        if (GameManager.picked && !doorOpened)
        {
            doorNumber = random.Next(0, 5);
            switch (doorNumber)
            {
                case 1:
                    door1.GetComponent<Renderer>().enabled = true;
                    break;
                case 2:
                    door2.GetComponent<Renderer>().enabled = true;
                    break;
                case 3:
                    door3.GetComponent<Renderer>().enabled = true;
                    break;
                default:
                    door4.GetComponent<Renderer>().enabled = true;
                    break;
            }
            doorOpened = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.GetComponent<Player>().isFlagPicked && gameObject.name == "Door" + doorNumber.ToString())
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
