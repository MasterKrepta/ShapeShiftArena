using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearchState : EnemyBaseState
{
    [SerializeField] public EnemyStateMachine _stateMachine;
    Vector3 velocity;
    public EnemySearchState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
        _stateMachine = enemyStateMachine;
    }

    public override void Attack()
    {

    }

    public override void Enter()
    {

    }
    public override void Tick(float deltaTime)
    {
        _stateMachine.Agent.destination = (_stateMachine.PlayerHealth.transform.position);
        //FaceMovementDirection(_stateMachine.PlayerHealth.transform.position, deltaTime);
    }
    public override void Exit()
    {

    }
}
