using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Door;
    private GameObject Doors;
    public bool picked = false;
    public Vector3 doorPosition;
    public GameObject flagOwner;

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
