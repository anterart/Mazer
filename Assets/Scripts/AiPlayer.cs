using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPlayer : Player
{
    GameGrid grid;
    GameObject gmObject;
    protected override void Awake()
    {
        base.Awake();
        gmObject = GameObject.Find("GameManager");
        grid = gmObject.GetComponent<GameGrid>();
    }


    protected override void Move()
    {
        Vector3 startPosition = transform.position;
        grid.StartPosition = transform;
        Vector3 targetPosition = GetTargetPosition();
        List<Node> path = Pathfinding.Astar(startPosition, targetPosition, grid);
        grid.FinalPath = path;
        if (path != null && path.Count > 0)
        {
            Node NextNode = path[0];
            Vector3 moveDirection = NextNode.Position - transform.position;
            float moveX = 0f;
            float moveZ = 0f;
            if (moveDirection.x > 0)
            {
                moveX = 1f;
            }
            if (moveDirection.x < 0)
            {
                moveX = -1f;
            }
            if (moveDirection.z > 0)
            {
                moveZ = 1f;
            }
            if (moveDirection.z < 0)
            {
                moveZ = -1f;
            }
            Vector3 movement = new Vector3(moveX, 0, moveZ);
            rb.velocity = movement * moveSpeed * Time.deltaTime;
        }
    }

    private Vector3 GetTargetPosition()
    {
        if (gm.picked)
        {
            if (GameObject.ReferenceEquals(gm.flagOwner, gameObject))
                {
                grid.TargetPosition = gm.Door.transform;
                return gm.doorPosition;
                }
            grid.TargetPosition = gm.flagOwner.transform;
            return gm.flagOwner.transform.position;
        }
        grid.TargetPosition = GameObject.Find("Flag").transform;
        return GameObject.Find("Flag").gameObject.transform.position;
    }

    protected override void Shoot()
    {
        // need to implement this function and once create a bullet here define it's "owner" member variable as "AI"
    }
}
