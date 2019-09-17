using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagScript : MonoBehaviour
{
    private float rotationSpeed = 2f;

    private void Awake()
    {

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
            Debug.Log("Touched flag");
            Destroy(gameObject);
            collider.GetComponent<Player>().isFlagPicked = true;
            GameManager.picked = true;
            GameManager.doorPosition = gameObject.transform.position;
        }
    }
}
