using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject owner;
    protected GameManager gm;
    private GameGrid grid;
    private bool isColliding = false;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        grid = gm.GetComponent<GameGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name != "Ground" && collider.tag != "flag" && collider.tag != "bullet" && !GameObject.ReferenceEquals(collider.gameObject, owner) && !isColliding)
        {
            isColliding = true;
            Destroy(gameObject);
            if (collider.tag == "Player" && !collider.GetComponent<Player>().isBeingShot) // bug here - isBeingShot turns true but never return to false therefore only first shot takes affect, need to fix this
            {
                collider.GetComponent<Player>().isBeingShot = true;
                collider.GetComponent<Player>().hp -= 30f;
                GameObject imageObject = GameObject.FindGameObjectWithTag("bar");
                Image healthImage = imageObject.GetComponent<Image>();
                if (collider.GetComponent<Player>().isHuman) // check if human player
                {
                    imageObject = GameObject.FindGameObjectWithTag("bar");
                    if (imageObject != null)
                    {
                        healthImage = imageObject.GetComponent<Image>();
                        if (collider.GetComponent<Player>().hp >= 0f) // check if life is above zero in current round to fill slider accordingly
                        {
                            healthImage.fillAmount = collider.GetComponent<Player>().hp / 100f;
                        }
                        else
                        {
                            healthImage.fillAmount = 0f;
                        }
                    }
                }
                if (collider.GetComponent<Player>().hp <= 0f) // check if player is dead
                {
                    if (collider.GetComponent<Player>().isFlagPicked) // check if player got the flag
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
                    }
                    if (imageObject != null && collider.GetComponent<Player>().isHuman) // check if player is dead human player
                    {
                        healthImage = imageObject.GetComponent<Image>();
                        healthImage.fillAmount = 1f;
                    }
                    Player colliderPlayer = collider.GetComponent<Player>();
                    Destroy(collider.gameObject);
                    Vector3 randomPosition = grid.GetRandomFreeNode();
                    GameObject newPlayer = Instantiate(colliderPlayer.prefab, new Vector3(randomPosition.x, collider.transform.position.y, randomPosition.z), Quaternion.identity) as GameObject;
                    newPlayer.transform.SetParent(gm.players.transform);
                }
                collider.GetComponent<Player>().isBeingShot = false;
            }
        }
    }
}
