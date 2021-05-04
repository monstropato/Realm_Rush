using UnityEngine;

public class Tile : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;

    //STATS
    Vector2Int coordinates = new Vector2Int();

    //CACHED CLASSES REFERENCES
    CoordinateLabeler coorLabeler;

    //CACHED EXTERNAL REFERENCES
    GridManager gridManager;
    Pathfinder pathfinder;

    //PROPERTIES
    public bool IsPlaceable { get { return isPlaceable; } }

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
        coorLabeler = GetComponentInChildren<CoordinateLabeler>();
    }

    private void Start()
    {
        if (gridManager)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) &&
            gridManager.GetNode(coordinates).isWalkable &&
            !pathfinder.WillBlockPath(coordinates))
        {
            bool isSucessful = towerPrefab.CreateTower(towerPrefab, transform.position, coorLabeler.Coordinates);
            if (isSucessful)
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyReceivers();
            }
        }
    }
}