using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    EnemyHealth[] enemies;
    EnemyHealth closestEnemy;
    float closestDist = float.PositiveInfinity;
    private void Awake()
    {
        enemies = GameObject.FindObjectsOfType<EnemyHealth>();

        foreach (var e in enemies)
        {
            var testdist = Vector3.Distance(transform.position, e.transform.position);

            if (testdist < closestDist)
            {
                closestDist = testdist;
                closestEnemy = e;
            }
        }
    }
    private void Update()
    {
        Vector3 moveDir = (closestEnemy.transform.position - transform.position + new Vector3(0, 1, 0)).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}