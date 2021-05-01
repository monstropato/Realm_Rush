using UnityEngine;
using UnityEditor;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    //CACHED COMPONENT REFERENCES
    TextMeshPro textCoordinates;
    Waypoint waypoint;

    //STATS
    private Vector2Int coordinates = new Vector2Int();

    //GET PARAMS
    public Vector2Int Coordinates { get { return coordinates; } }

    private void Awake()
    {
        textCoordinates = GetComponent<TextMeshPro>();
        textCoordinates.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            textCoordinates.enabled = true;
            DisplayCoordinates();
            UpdateObjectName();
        }

        ColorCoordinates();
        ToggleLabels();
    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.L) && Debug.isDebugBuild)
        {
            textCoordinates.enabled = !textCoordinates.IsActive();
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / EditorSnapSettings.move.z);

        textCoordinates.text = $"{coordinates}";
    }

    private void UpdateObjectName()
    {
        transform.parent.name = $"Tile {coordinates}";
    }

    private void ColorCoordinates()
    {
        if (waypoint.IsPlaceable)
        {
            textCoordinates.color = defaultColor;
        }
        else
        {
            textCoordinates.color = blockedColor;
        }
    }
}