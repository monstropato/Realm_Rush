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

    //PROPERTIES
    public bool IsPlaceable { get { return isPlaceable; } }

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
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
        if (Input.GetMouseButtonDown(0) && isPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position, coorLabeler.Coordinates);
            isPlaceable = !isPlaced;
        }
    }
}
