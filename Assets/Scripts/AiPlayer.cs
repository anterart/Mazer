using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPlayer : Player
{
    public static float shootingRadiusThreshold = 17f;
    public static float shootingDelayInSeconds = 1f;
    public static float shootingNoiseFactor = 5f;
    private float shootingTimePassed = 0;
    Animator anim;

    protected override void Awake()
    {
        base.Awake();
        prefab = gm.GetComponent<GameManager>().aiPlayer;
        isHuman = false;
        anim = GetComponentInChildren<Animator>();
    }

    protected override void Start()
    {
        base.Start();
        moveSpeed = 300f;
        if (gm.isTutorial)
        {
            moveSpeed = 0f;
            shootingRadiusThreshold = 7f;
            shootingDelayInSeconds = 2f;
            shootingNoiseFactor = 10f;
        }
    }


    protected override void Move()
    {
        if (!gm.isTutorial)
        {
            anim.SetBool("walking", true);
        }
        Vector3 startPosition = transform.position;
        grid.StartPosition = transform;
        Vector3 targetPosition = GetTargetPosition();
        List<Node> path = Pathfinding.Astar(startPosition, targetPosition, grid);
        grid.FinalPath = path;
        if (path != null && path.Count > 0)
        {
            Node NextNode = path[0];
            Vector3 moveDirection = NextNode.Position - transform.position;
            float moveDirectionSum = Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z);
            float moveX = moveDirection.x / moveDirectionSum;
            float moveZ = moveDirection.z / moveDirectionSum;

            Vector3 movement = new Vector3(moveX, 0, moveZ);
            rb.velocity = movement * moveSpeed * Time.deltaTime;
            Vector3 lookAt = new Vector3(NextNode.Position.x, transform.position.y, NextNode.Position.z);
            transform.LookAt(lookAt);
        }
        else
        {
            Vector3 moveDirection = targetPosition - transform.position;
            float moveDirectionSum = Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z);
            float moveX = moveDirection.x / moveDirectionSum;
            float moveZ = moveDirection.z / moveDirectionSum;

            Vector3 movement = new Vector3(moveX, 0, moveZ);
            rb.velocity = movement * moveSpeed * Time.deltaTime;
            Vector3 lookAt = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
            transform.LookAt(lookAt);
        }
    }

    protected override void Shoot()
    {
        if (shootingTimePassed > shootingDelayInSeconds)
        {
            shootingTimePassed = 0;
            List<GameObject> theySeeMe = gm.GetPlayersInDirectSight(gameObject);
            if (theySeeMe.Count > 0)
            {
                theySeeMe.Sort((x, y) => Vector3.Distance(gameObject.transform.position, x.transform.position).CompareTo(Vector3.Distance(gameObject.transform.position, y.transform.position)));
                GameObject closestEnemy = theySeeMe[0];
                if (Vector3.Distance(closestEnemy.transform.position, gameObject.transform.position) <= shootingRadiusThreshold)
                {
                    float shootingNoiseX = Random.Range(- shootingNoiseFactor / 2, shootingNoiseFactor / 2);
                    float shootingNoiseZ = Random.Range(-shootingNoiseFactor / 2, shootingNoiseFactor / 2);
                    Vector3 shootingNoise = new Vector3(shootingNoiseX, 0, shootingNoiseZ);
                    base.ShootHelper(closestEnemy.transform.position + shootingNoise);
                }
            }
        }
        else
        {
            shootingTimePassed += Time.deltaTime;
        }
    }
}
