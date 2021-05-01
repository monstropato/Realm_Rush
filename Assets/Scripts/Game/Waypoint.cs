using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;

    //CACHED CLASSES REFERENCES
    CoordinateLabeler coorLabeler;

    //GET PARAMS
    public bool IsPlaceable { get { return isPlaceable; } }

    private void Start()
    {
        coorLabeler = GetComponentInChildren<CoordinateLabeler>();
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
