﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    GameGrid grid;
    Transform StartPosition;
    Transform TargetPosition;

    private void Awake()
    {
        grid = GetComponent<GameGrid>();
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
