using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject owner;
    protected GameManager gm;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name != "Ground" && !GameObject.ReferenceEquals(collider.gameObject, owner))
        {
            Destroy(gameObject);
            if (collider.tag == "Player")
            {
                collider.GetComponent<Player>().hp -= 100;
                if (collider.GetComponent<Player>().hp <= 0f)
                {
                    if (collider.GetComponent<Player>().isFlagPicked)
                    {
                        gm.picked = false;
                        collider.GetComponent<Player>().isFlagPicked = false;
                        foreach (Transform Door in gm.Doors.transform)
                        {
                            Door.gameObject.SetActive(false);
                        }
                        gm.flagOwner = null;
                        GameObject flag = Instantiate(gm.flagPrefab, collider.transform.position, Quaternion.identity) as GameObject;
                        flag.name = "Flag";
                        // need to re-spawn the dead player (need to check if it is a human or a AI one);
                    }
                    Player colliderPlayer = collider.GetComponent<Player>();
                    GameObject newPlayer = Instantiate(colliderPlayer.prefab, colliderPlayer.startingPlyerPosition, Quaternion.identity) as GameObject;
                    Destroy(collider.gameObject);
                }
            }
        }
        
    }
}
