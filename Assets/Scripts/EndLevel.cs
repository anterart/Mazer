using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    GameObject door;
    public int levelToLoad;

    private void Start()
    {
        door = GameObject.Find("Door");
    }
    void Update()
    {
        if (PlayerMovement.picked)
        {
            door.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            door.GetComponent<Renderer>().enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.GetComponent<PlayerMovement>().isFlagPicked)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
