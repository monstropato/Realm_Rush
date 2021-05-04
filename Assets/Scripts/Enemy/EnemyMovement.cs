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

        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    private void FindPath()
    {
        path.Clear();
        path = enemy.pathfinder.GetNewPath();
    }

    private void ReturnToStart()
    {
        transform.position = enemy.gridManager.GetPositionFromCoordinates(enemy.pathfinder.StartNode.coordinates);
        path.Remove(path[0]);
    }

    private IEnumerator FollowPath()
    {
        for (int i = 0; i < path.Count; i++)
        {
            //Debug.Log(i);
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