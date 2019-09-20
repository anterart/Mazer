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

    private void Awake()
    {
        Doors = GameObject.Find("Doors");
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
}
