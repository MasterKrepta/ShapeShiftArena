using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }

    void TakeDamage(float dmg);

    void Die();

}
