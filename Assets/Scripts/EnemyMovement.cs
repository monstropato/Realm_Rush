using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //CONFIG PARAMS
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
        transform.position = enemy.patch[0].transform.position;
        foreach(Waypoint waypoint in enemy.patch)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercent = 0f;

            while (travelPercent < 1)
            {
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                travelPercent += Time.deltaTime * speed;
                yield return new WaitForEndOfFrame();
            }
        }
        transform.position = enemy.patch[enemy.patch.Count-1].transform.position;
    }
}