using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    //CONFIG PARAMS
    [Header("Color")]
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);
    [Header("Grid")]
    [SerializeField] float snapSettings = 10f;

    //CACHED COMPONENT REFERENCES
    TextMeshPro textCoordinates;

    //CACHED EXTERNAL REFERENCES
    GridManager gridManager;
    //STATS
    private Vector2Int coordinates = new Vector2Int();

    //PROPERTIES
    public Vector2Int Coordinates { get { return coordinates; } }

    private void Awake()
    {
        //IN PLAY MODE
        gridManager = FindObjectOfType<GridManager>();
        textCoordinates = GetComponent<TextMeshPro>();
        textCoordinates.enabled = false;
        CalculateCoordinates();
        DisplayCoordinates();
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            //IN EDITOR MODE
            textCoordinates.enabled = true;
            CalculateCoordinates();
            DisplayCoordinates();
            UpdateObjectName();
        }

        SetLabelcolor();
        ToggleLabels();
    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.L) && Debug.isDebugBuild)
        {
            textCoordinates.enabled = !textCoordinates.IsActive();
        }
    }

    private void CalculateCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / snapSettings);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / snapSettings);
    }

    private void DisplayCoordinates()
    {
        textCoordinates.text = $"{coordinates}";
    }

    private void UpdateObjectName()
    {
        transform.parent.name = $"Tile {coordinates}";
    }

    private void SetLabelcolor()
    {
        if(!gridManager) { return; }

        Node node = gridManager.GetNode(coordinates);
        if (node == null) { return; }

        if (!node.isWalkable)
        {
            textCoordinates.color = blockedColor;
        }
        else if (node.isPath)
        {
            textCoordinates.color = pathColor;
        }
        else if (node.isExplored)
        {
            textCoordinates.color = exploredColor;
        }
        else
        {
            textCoordinates.color = defaultColor;
        }
    }
}