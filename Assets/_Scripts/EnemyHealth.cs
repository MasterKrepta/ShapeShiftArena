using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    private float _currentHealth;
    public float CurrentHealth
    {
        get { return _currentHealth; }
        set
        {
            _currentHealth = value;
            if (CurrentHealth <= 0)
                Die();
        }
    }

    [SerializeField] float _maxHealth;
    public float MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }



    void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }

    public void TakeDamage(float dmg)
    {
        CurrentHealth -= dmg;

    }





}
