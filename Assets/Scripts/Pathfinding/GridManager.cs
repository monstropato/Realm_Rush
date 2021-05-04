using System;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] Vector2Int gridSize;
    [SerializeField] int gridSnapSize = 10;

    //STATS
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    //PROPERTIES
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }
    public int GridSnapSize { get { return gridSnapSize; } }


    private void Awake()
    {
        CreateGrid();
    }

    public Node GetNode(Vector2Int coordinate)
    {
        if (grid.ContainsKey(coordinate))
        {
            return grid[coordinate];
        }
        else
        {
            return null;
        }
    }

    private void CreateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));
            }
        }
    }
}