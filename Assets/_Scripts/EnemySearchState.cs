
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearchState : EnemyBaseState
{
    [SerializeField] public EnemyStateMachine _stateMachine;
    int rng;
    float NextAttackTime;
    float delay = 1.5f;
    Vector3 velocity;
    bool canAttack = true;
    public EnemySearchState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
        _stateMachine = enemyStateMachine;
    }

    public override void Attack()
    {
        BeginAttack(_stateMachine.IsRanged);
    }

    private void BeginAttack(bool isRanged)
    {
        if (isRanged)
        {
            _stateMachine.Anim.SetTrigger("throw");
        }
        else
        {
            _stateMachine.Anim.SetTrigger("attack");
        }
    }

    public override void Enter()
    {
        rng = UnityEngine.Random.Range(0, 1);
        _stateMachine.IsRanged = Convert.ToBoolean(rng);
        _stateMachine.Agent.stoppingDistance = _stateMachine.IsRanged == true ? 5 : 3;
    }
    public override void Tick(float deltaTime)
    {
        _stateMachine.Agent.destination = (_stateMachine.Player.transform.position);
        if (_stateMachine.Agent.remainingDistance <= _stateMachine.Agent.stoppingDistance && canAttack)
        {
            canAttack = false;
            ResetAttackTime();
            Attack();

        }

        if (canAttack) return;

        if (Time.time > NextAttackTime)
            canAttack = true;
    }

    void ResetAttackTime()
    {
        NextAttackTime = Time.time + delay;

    }
    public override void Exit()
    {

    }
}
