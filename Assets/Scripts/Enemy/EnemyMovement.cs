using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class EnemyMovement : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField][Range(0f,5f)] float speed =1f;

    //STATS
    List<Node> path = new List<Node>();

    //CACHED CLASSES REFERENCES
    Enemy enemy;


    internal void CustomStart()
    {
        enemy = GetComponent<Enemy>();

        ReturnToStart();
        RecalculatePath(true);
    }

    private void RecalculatePath(bool resetPath)
    {
        Vector2Int coordinates = new Vector2Int();
        if (resetPath)
        {
            coordinates = enemy.pathfinder.StartNode.coordinates;
        }
        else
        {
            coordinates = enemy.gridManager.GetCoordinatesFromPosition(transform.position);
        }

        StopAllCoroutines();
        path.Clear();
        path = enemy.pathfinder.GetNewPath(coordinates);
        StartCoroutine(FollowPath());
    }

    private void ReturnToStart()
    {
        Vector3 startPos = enemy.gridManager.GetPositionFromCoordinates(enemy.pathfinder.StartNode.coordinates);
        transform.position = startPos;
    }

    private IEnumerator FollowPath()
    {
        for (int i = 1; i < path.Count; i++)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = enemy.gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;

            transform.LookAt(endPos);
            while (travelPercent < 1)
            {
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                travelPercent += Time.deltaTime * speed;
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }

    private void FinishPath()
    {
        transform.position = enemy.gridManager.GetPositionFromCoordinates(enemy.pathfinder.DestinationNode.coordinates);
        enemy.Despawn();
        enemy.enemyCurrency.StealGold();
    }
}