using UnityEngine;
using UnityEditor;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    //CACHED COMPONENT REFERENCES
    TextMeshPro coordinateSystem;

    //STATS
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        coordinateSystem = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }

    private void Update()
    {
        if (Application.isPlaying)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            DisplayCoordinates();
            UpdateObjectName();
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / EditorSnapSettings.move.z);

        coordinateSystem.text = $"{coordinates}";
    }

    private void UpdateObjectName()
    {
        transform.parent.name = $"Tile {coordinates}";
    }
}