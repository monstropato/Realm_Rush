using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] float waitTime = 1f;

    //CACHED CLASSES REFERENCES
    Enemy enemy;

    internal void CustomStart()
    {
        enemy = GetComponent<Enemy>();

        StartCoroutine(FollowPatch());
    }

    private IEnumerator FollowPatch()
    {
        foreach(Waypoint waypoint in enemy.patch)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
