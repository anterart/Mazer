using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Door;
    public GameObject Doors;
    public bool picked = false;
    public Vector3 doorPosition;
    public GameObject flagOwner;
    public GameObject flagPrefab;
    public GameObject humanPlayer;
    public GameObject aiPlayer;
    private GameObject players;
    public int playersLayer;

    private void Awake()
    {
        Doors = GameObject.Find("Doors");
        players = GameObject.Find("Players");
        foreach (Transform Door in Doors.transform)
        {
            Door.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> GetPlayersInDirectSight(GameObject me)
    {
        List<GameObject> theySeeMe = new List<GameObject>();
        foreach (Transform playerTransform in players.transform)
        {
            if (!GameObject.ReferenceEquals(playerTransform.gameObject, me))
            {
                if (IsInDirectSight(playerTransform.position, me.transform.position))
                {
                    theySeeMe.Add(playerTransform.gameObject);
                }
            }
        }
        return theySeeMe;
    }

    private bool IsInDirectSight(Vector3 origin, Vector3 destination)
    {
        //if (Physics.Raycast())
        return true;
    }
}
