using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPlayer : Player
{
    GameGrid grid;
    GameManager gm;
    protected override void Awake()
    {
        base.Awake();
        grid = GetComponent<GameGrid>();
        gm = GetComponent<GameManager>();
    }


    protected override void Move()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = GetTargetPosition();
    }

    private Vector3 GetTargetPosition()
    {
        return new Vector3(1, 1, 1);
    }
}
