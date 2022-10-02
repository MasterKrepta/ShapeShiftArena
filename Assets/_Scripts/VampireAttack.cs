using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireAttack : MonoBehaviour
{
    PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IHealth>(out IHealth health))
        {
            //Debug.Log(other.name + " takes damage");
            health.TakeDamage(10);
            playerHealth.Heal(10);

        }

    }
}
