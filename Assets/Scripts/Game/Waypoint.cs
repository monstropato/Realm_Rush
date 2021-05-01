using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;

    //GET PARAMS
    public bool IsPlaceable { get { return isPlaceable; } }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceable)
        {
            InstantiateTower();
        }
    }

    private void InstantiateTower()
    {
        Tower newTower = Instantiate(towerPrefab, transform.position, Quaternion.identity);
        newTower.name = $"{towerPrefab.name} {GetComponentInChildren<CoordinateLabeler>().Coordinates}";
        isPlaceable = false;
    }
}
