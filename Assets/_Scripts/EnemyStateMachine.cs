using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine
{

    public Animator Anim;
    public CharacterController cc;
    public NavMeshAgent Agent;
    public PlayerHealth PlayerHealth;
    public float RotationDamping = 30;
    private void Start()
    {
        PlayerHealth = FindObjectOfType<PlayerHealth>();
        Agent = GetComponent<NavMeshAgent>();
        cc = GetComponent<CharacterController>();
        Anim = GetComponentInChildren<Animator>();
        SwitchState(new EnemySearchState(this));
    }


}
