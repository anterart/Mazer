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
    protected float bulletSpeed = 80f;
    protected GameManager gm;
    // Start is called before the first frame update

    protected virtual void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        checkDeath();
    }

    protected virtual void Move()
    {

    }

    protected virtual void Shoot()
    {
       
    }

    private void checkDeath()
    {
        if (hp <= 0f)
        {
            if (isFlagPicked)
            {
                gm.picked = false;
                isFlagPicked = false;
                // need to instantiate new flag in this location and re-spawn the dead player (need to check if it is 
                // a human or a AI one);
                // Instantiate(FlagScript., transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

}
