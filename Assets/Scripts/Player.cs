using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isFlagPicked = false;
    protected Rigidbody rb;
    public Vector3 playerPosition;
    public float hp = 100f;
    protected float moveSpeed = 300f;
    protected float bulletSpeed = 40f;
    protected GameManager gm;
    public Vector3 startingPlyerPosition;
    public GameObject prefab;

    // Start is called before the first frame update

    protected virtual void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerPosition = transform.position;
        startingPlyerPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = transform.position;
        Move();
        Shoot();
    }

    protected virtual void Move()
    {

    }

    protected virtual void Shoot()
    {
       
    }
}
