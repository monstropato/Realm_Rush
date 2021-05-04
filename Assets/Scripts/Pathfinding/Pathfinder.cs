using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentNode;
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
        
    }
}
