using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinationCoordinates;

    //STATS
    Node startNode;
    Node destinationNode;
    Node currentSearchNode;

    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>(); //this lookup reference to see if that node is explored or not

    Queue<Node> frontier = new Queue<Node>();
    #region What is a Queue?
    //frontier is another variable, all the nodes that got queued for searching through the neighbours, but is still to be looked to see if it's going to be part of the path or not.
    //we're going to use a new data type: Queue.
    //queue is a special kind of list, that enforces a FIFO (First In, First Out) order
    //it's write Quewe<Node> queue
    //queue.Enqueue() adds to the end of queue
    //queue.Dequeue() Removes and returs the front of queue
    //queue.Peek() only rerturns the front of queue
    #endregion

    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    
    //CACHED EXTERNAL REFERENCES
    GridManager gridManager;

    //PROPERTIES
    public Node StartNode{ get { return startNode; } }
    public Node DestinationNode { get { return destinationNode; } }


    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();

        startNode = gridManager.Grid[startCoordinates];
        destinationNode = gridManager.Grid[destinationCoordinates];
    }

    void Start()
    {
        GetNewPath();
    }

    public List<Node> GetNewPath()
    {
        gridManager.ResetNodes();
        frontier.Clear();
        reached.Clear();

        BreadthFirstSearch();
        return BuildPath();
    }

    private void BreadthFirstSearch()
    {
        startNode.isWalkable = true;
        destinationNode.isWalkable = true;

        bool isRunning = true;

        frontier.Enqueue(startNode);
        reached.Add(startNode.coordinates, startNode);

        while(frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            //Debug.Log(currentSearchNode.coordinates);
            currentSearchNode.isExplored = true;
            ExploreNeighbours();
            if(currentSearchNode == destinationNode)
            {
                isRunning = false;
            }
        }
    }

    private void ExploreNeighbours()
    {
        Node neighbour;
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoords = currentSearchNode.coordinates + direction;

            if (gridManager.Grid.ContainsKey(neighbourCoords))
            {
                neighbour = gridManager.Grid[neighbourCoords];
                if (!reached.ContainsKey(neighbour.coordinates) && neighbour.isWalkable)
                {
                    neighbour.connectedTo = currentSearchNode;
                    reached.Add(neighbour.coordinates, neighbour);
                    frontier.Enqueue(neighbour);
                }
            }
        }
    }

    private List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode;

        path.Add(currentNode);
        currentNode.isPath = true;

        while(currentNode.connectedTo != null)
        {
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
            currentNode.isPath = true;
        }
        path.Reverse();
        return path;
    }

    public bool WillBlockPath(Vector2Int coordinates)
    {
        if(gridManager.Grid.ContainsKey(coordinates))
        {
            bool previousState = gridManager.Grid[coordinates].isWalkable;

            gridManager.Grid[coordinates].isWalkable = false;
            List<Node> newPath = GetNewPath();
            gridManager.Grid[coordinates].isWalkable = previousState;
            if(newPath.Count <= 1)
            {
                GetNewPath();
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void NotifyReceivers()
    {
        BroadcastMessage("RecalculatePath", SendMessageOptions.DontRequireReceiver);
    }
}