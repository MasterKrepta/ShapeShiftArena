using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent<PlayerHealth>(out PlayerHealth health))
        {
            Debug.Log(other.name + " takes damage");
            health.TakeDamage(10);
            Destroy(this.gameObject);
        }
    }

}
