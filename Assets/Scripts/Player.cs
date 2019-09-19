using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isFlagPicked = false;
    protected Rigidbody rb;
    public Vector3 playerPosition;
    // Start is called before the first frame update

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerPosition = transform.position;
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
