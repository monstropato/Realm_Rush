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
    #region What is a Dictionary?
    //dictionaries stores a key-value pair. Like a real physical dictionary, the key would be the word, and the value, the description.
    //keys are linked to value, must be unique, can't be null, and are usually very simple. In this game, they are the coordinates.
    //values can be more complex types and can be null. In this game, they are the Node.
    //The lookup is very fast from key to value, but slow in the other way
    #endregion

    //PROPERTIES
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }
    public int GridSnapSize { get { return gridSnapSize; } }


    private void Awake()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));
                //TODO: Make so is only added to the grid where it have tiles
                //Debug.Log($"{grid[coordinates].coordinates} = {grid[coordinates].isWalkable}");
            }
        }
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

    public void BlockNode(Vector2Int coordinate)
    {
        if (grid.ContainsKey(coordinate))
        {
            grid[coordinate].isWalkable = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / GridSnapSize);
        coordinates.y = Mathf.RoundToInt(position.z / GridSnapSize);
        return coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = Mathf.RoundToInt(position.x * GridSnapSize);
        position.z = Mathf.RoundToInt(position.y * GridSnapSize);
        return position;
    }
}