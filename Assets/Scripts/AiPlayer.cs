using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPlayer : Player
{
    GameGrid grid;
    GameObject gmObject;
    public const float pathCalculationDelaySeconds = 0f;

    protected override void Awake()
    {
        base.Awake();
        gmObject = GameObject.Find("GameManager");
        grid = gmObject.GetComponent<GameGrid>();
        prefab = gm.GetComponent<GameManager>().aiPlayer;
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
            float moveDirectionSum = Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z);
            float moveX = moveDirection.x / moveDirectionSum;
            float moveZ = moveDirection.z / moveDirectionSum;

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
