using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class EnemyMovement : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] internal List<Waypoint> patch = new List<Waypoint>();
    [SerializeField][Range(0f,5f)] float speed =1f;

    //CACHED CLASSES REFERENCES
    Enemy enemy;

    internal void CustomStart()
    {
        enemy = GetComponent<Enemy>();

        StartCoroutine(FollowPatch());
    }

    private IEnumerator FollowPatch()
    {
        transform.position = patch[0].transform.position;
        foreach(Waypoint waypoint in patch)
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
        transform.position = patch[patch.Count-1].transform.position;
    }
}
