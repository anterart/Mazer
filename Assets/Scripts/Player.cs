using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isFlagPicked = false;
    protected Rigidbody rb;
    public Vector3 playerPosition;
    public float hp = 100f;
    protected float moveSpeed;
    protected float bulletSpeed = 40f;
    protected GameManager gm;
    public Vector3 startingPlyerPosition;
    public GameObject prefab;
    public GameObject bulletPrefab;
    public bool isBeingShot = false;
    public bool isHuman;
    public AudioSource audioSrc;
    public AudioClip[] hurtSounds;
    public GameObject flagOwner;
    protected GameGrid grid;
    protected GameObject gmObject;
    // Start is called before the first frame update

    protected virtual void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSrc = GetComponent<AudioSource>();
        gmObject = GameObject.Find("GameManager");
    }

    protected virtual void Start()
    {
        grid = gmObject.GetComponent<GameGrid>();
        rb = GetComponent<Rigidbody>();
        playerPosition = transform.position;
        startingPlyerPosition = transform.position;
        flagOwner = transform.Find("FlagOwner").gameObject;
        flagOwner.SetActive(false);
    }

    // Update is called once per frame
    protected virtual void Update()
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

    protected void ShootHelper(Vector3 target)
    {
        audioSrc.Play();
        Vector3 dir = (target - (new Vector3(transform.position.x, transform.position.y, transform.position.z))).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0.5f, 0), Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = dir * bulletSpeed;
        bullet.GetComponent<BulletBehavior>().owner = gameObject;
    }

    public Vector3 GetTargetPosition()
    {
        if (gm.picked)
        {
            if (GameObject.ReferenceEquals(gm.flagOwner, gameObject))
            {
                grid.TargetPosition = gm.Door.transform;
                return gm.doorPosition;
            }
            if (gm.flagOwner != null)
            {
                grid.TargetPosition = gm.flagOwner.transform;
                return gm.flagOwner.transform.position;
            }
        }
        grid.TargetPosition = GameObject.Find("Flag").transform;
        return GameObject.Find("Flag").gameObject.transform.position;
    }
}
