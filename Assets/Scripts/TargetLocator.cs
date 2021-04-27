using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] GameObject weapon;

    //STATES
    Enemy enemy;

    void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        weapon.transform.LookAt(enemy.transform);
    }
}
