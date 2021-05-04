using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    GridManager gridManager;


    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }
    void Start()
    {
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        List<Node> neighbours = new List<Node>();
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoords = currentSearchNode.coordinates + direction;
            if (gridManager.Grid.ContainsKey(neighbourCoords))
            {
                neighbours.Add(gridManager.Grid[neighbourCoords]);

                //TODO remove after testing
                gridManager.Grid[neighbourCoords].isExplored = true;
                gridManager.Grid[currentSearchNode.coordinates].isPath = true;
            }
        }
    }
}
