using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public string owner;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name != "Ground" && collider.gameObject.name != "Player1")
        {
            Destroy(gameObject);
        }
        if ((collider.gameObject.name == "Player2" && owner == "Human") || (collider.gameObject.name == "Player1" && owner == "AI"))
        {
            collider.GetComponent<Player>().hp -= 20;
        }
    }
}
