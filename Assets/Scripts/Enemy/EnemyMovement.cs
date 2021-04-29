using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class EnemyMovement : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField][Range(0f,5f)] float speed =1f;

    //STATS
    List<Waypoint> path = new List<Waypoint>();

    //CACHED CLASSES REFERENCES
    Enemy enemy;

    //CACHED STRINGS
    const string TAG_PATH = "Path";


    internal void CustomStart()
    {
        enemy = GetComponent<Enemy>();

        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPatch());
    }

    private void FindPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag(TAG_PATH);

        foreach(Transform child in parent.transform)
        {
            path.Add(child.GetComponent<Waypoint>());
        }
    }

    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
        path.Remove(path[0]);
    }

    private IEnumerator FollowPatch()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPos);
            while (travelPercent < 1)
            {
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                travelPercent += Time.deltaTime * speed;
                yield return new WaitForEndOfFrame();
            }
        }
        transform.position = path[path.Count-1].transform.position;
        enemy.Despawn();
    }
}
