using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isClickable;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isClickable)
        {
            Debug.Log(name);
        }
    }
}
