using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] GameObject towerPrefab;
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
        Instantiate(towerPrefab, transform.position, Quaternion.identity);
        isPlaceable = false;
    }
}
