using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine
{

    public Animator Anim;
    public bool IsRanged = false;

    public NavMeshAgent Agent;
    public Transform Player;
    public float RotationDamping = 30;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Agent = GetComponent<NavMeshAgent>();

        Anim = GetComponentInChildren<Animator>();
        SwitchState(new EnemySearchState(this));
    }


}
