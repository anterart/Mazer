using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour
{
    private float rotationSpeed = 2f;
    GameObject doors;
    GameManager gm;

    private void Awake()
    {
        doors = GameObject.Find("Doors");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            collider.GetComponent<Player>().isFlagPicked = true;
            gm.picked = true;
            gm.flagOwner = collider.gameObject;
            System.Random random = new System.Random();
            int doorNumber = random.Next(4);
            gm.doorPosition = doors.transform.GetChild(doorNumber).position;
            gm.Door = doors.transform.GetChild(doorNumber).gameObject;
            Debug.Log(doorNumber);
            doors.transform.GetChild(doorNumber).gameObject.SetActive(true);
        }
    }
}
