using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerewolfDamage : MonoBehaviour
{
    EnemyHealth[] enemies;
    EnemyHealth closestEnemy;
    float closestDist = float.PositiveInfinity;
    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<IHealth>(out IHealth health))
        {
            Debug.Log(other.name + " takes damage");
            health.TakeDamage(10);

        }
    }
    private void Update()
    {
    }

    void GetClosestTarget()
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
}
