using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<EnemyHealth>(out EnemyHealth health))
        {
            Debug.Log(other.name + " takes damage");
            health.TakeDamage(10);
            Destroy(this.gameObject);
        }
    }
}
