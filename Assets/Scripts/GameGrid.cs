using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public Transform StartPosition;
    public Transform TargetPosition;
    public LayerMask WallMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public float Distance;

    Node[,] grid;
    public List<Node> freeNodes = new List<Node>();
    public List<Node> FinalPath;

    float nodeDiameter;
    int gridSizeX, gridSizeY;
    // Start is called before the first frame update
    void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 bottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = bottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool Wall = false;

                if (Physics.CheckSphere(worldPoint, nodeRadius, WallMask))
                {
                    Wall = true;
                }

                grid[x, y] = new Node(Wall, worldPoint, x, y);
            }
        }
        CreateFreeNodesList();
    }

    void CreateFreeNodesList()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                if (!grid[x, y].IsWall)
                {
                    freeNodes.Add(grid[x, y]);
                }
            }
        }
    }

    public Vector3 GetRandomFreeNode()
    {
        System.Random random = new System.Random();
        return freeNodes[random.Next(freeNodes.Count)].Position;
    }

    public Node NodeFromWorldPosition(Vector3 a_WorldPosition)
    {
        float xpoint = ((a_WorldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x);
        float ypoint = ((a_WorldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y);

        xpoint = Mathf.Clamp01(xpoint);
        ypoint = Mathf.Clamp01(ypoint);

        int x = Mathf.RoundToInt((gridSizeX - 1) * xpoint);
        int y = Mathf.RoundToInt((gridSizeY - 1) * ypoint);

        return grid[x, y];
    }

    public List<Node> GetNeighboringNodes(Node a_Node)
    {
        List<Node> NeighboringNodes = new List<Node>();
        int xCheck;
        int yCheck;

        //Right Side
        xCheck = a_Node.gridX + 1;
        yCheck = a_Node.gridY;
        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                NeighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Left Side
        xCheck = a_Node.gridX - 1;
        yCheck = a_Node.gridY;
        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                NeighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Top Side
        xCheck = a_Node.gridX;
        yCheck = a_Node.gridY + 1;
        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                NeighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Bottom Side
        xCheck = a_Node.gridX;
        yCheck = a_Node.gridY - 1;
        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                NeighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        ////Top-Right Side
        //xCheck = a_Node.gridX + 1;
        //yCheck = a_Node.gridY + 1;
        //if (xCheck >= 0 && xCheck < gridSizeX)
        //{
        //    if (yCheck >= 0 && yCheck < gridSizeY)
        //    {
        //        NeighboringNodes.Add(grid[xCheck, yCheck]);
        //    }
        //}

        ////Top-Left Side
        //xCheck = a_Node.gridX - 1;
        //yCheck = a_Node.gridY + 1;
        //if (xCheck >= 0 && xCheck < gridSizeX)
        //{
        //    if (yCheck >= 0 && yCheck < gridSizeY)
        //    {
        //        NeighboringNodes.Add(grid[xCheck, yCheck]);
        //    }
        //}

        ////Bottom-Right Side
        //xCheck = a_Node.gridX + 1;
        //yCheck = a_Node.gridY - 1;
        //if (xCheck >= 0 && xCheck < gridSizeX)
        //{
        //    if (yCheck >= 0 && yCheck < gridSizeY)
        //    {
        //        NeighboringNodes.Add(grid[xCheck, yCheck]);
        //    }
        //}

        ////Bottom-Left Side
        //xCheck = a_Node.gridX - 1;
        //yCheck = a_Node.gridY - 1;
        //if (xCheck >= 0 && xCheck < gridSizeX)
        //{
        //    if (yCheck >= 0 && yCheck < gridSizeY)
        //    {
        //        NeighboringNodes.Add(grid[xCheck, yCheck]);
        //    }
        //}

        return NeighboringNodes;
    }

    public Node GetNonWallNeighbor(Node n)
    {
        Node right = grid[n.gridX + 1, n.gridY];
        if (!right.IsWall)
        {
            return right;
        }

        Node left = grid[n.gridX - 1, n.gridY];
        if (!left.IsWall)
        {
            return left;
        }

        Node up = grid[n.gridX, n.gridY + 1];
        if (!up.IsWall)
        {
            return up;
        }

        Node down = grid[n.gridX, n.gridY - 1];
        if (!down.IsWall)
        {
            return down;
        }

        Node upRight = grid[n.gridX + 1, n.gridY + 1];
        if (!upRight.IsWall)
        {
            return upRight;
        }

        Node upLeft = grid[n.gridX - 1, n.gridY + 1];
        if (!upLeft.IsWall)
        {
            return upLeft;
        }

        Node downRight = grid[n.gridX + 1, n.gridY - 1];
        if (!downRight.IsWall)
        {
            return downRight;
        }

        Node downLeft = grid[n.gridX - 1, n.gridY - 1];
        if (!downLeft.IsWall)
        {
            return downLeft;
        }

        return n;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

        if (grid != null)
        {
            foreach(Node node in grid)
            {
                if (node.IsWall)
                {
                    Gizmos.color = Color.yellow;
                }
                else
                {
                    Gizmos.color = Color.white;
                }
                if (FinalPath != null)
                {
                    if (FinalPath.Contains(node))
                    {
                        Gizmos.color = Color.red;
                    }
                }
                Gizmos.DrawCube(node.Position, Vector3.one * (nodeDiameter - Distance));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
