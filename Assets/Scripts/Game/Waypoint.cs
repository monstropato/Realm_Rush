using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isClickable;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isClickable)
        {
            InstantiateTower();
        }
    }

    private void InstantiateTower()
    {
        Instantiate(towerPrefab, transform.position, Quaternion.identity);
        isClickable = false;
    }
}
