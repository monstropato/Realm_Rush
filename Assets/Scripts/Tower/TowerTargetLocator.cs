using UnityEngine;

internal class TowerTargetLocator : MonoBehaviour
{
    //CONFIG PARAMS

    //STATES
    Enemy currentEnemy;

    //CACHED CLASSES REFERENCES
    Tower tower;

    internal void CustomStart()
    {
        tower = GetComponent<Tower>();

        currentEnemy = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!currentEnemy) { return; }

        tower.weapon.transform.LookAt(currentEnemy.transform.position);
    }
}