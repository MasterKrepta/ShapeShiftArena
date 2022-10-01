using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDamage : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IHealth>(out IHealth health))
        {
            Debug.Log(other.name + " takes damage");
            health.TakeDamage(10);
        }

    }


}
