using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    public PlayerStateMachine _stateMachine;
    public float _maxHealth;
    public float MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    public float _currentHealth;
    public float CurrentHealth
    {
        get { return _currentHealth; }
        set
        {
            _currentHealth = Mathf.Clamp(value, 0, MaxHealth);

            if (_currentHealth <= 0)
                Die();
        }
    }

    private void Start()
    {

        CurrentHealth = MaxHealth;

    }

    private void OnTest()
    {
        Heal(10);
    }

    public void Die()
    {

    }

    public void TakeDamage(float dmg)
    {
        CurrentHealth -= dmg;
    }

    public void Heal(float amt)
    {
        Debug.Log("Heal 10 points");
        CurrentHealth += amt;

    }


}
