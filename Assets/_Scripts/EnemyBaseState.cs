using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : BaseState
{
    [SerializeField] public EnemyStateMachine _stateMachine;


    public EnemyBaseState(EnemyStateMachine enemyStateMachine)
    {
        _stateMachine = enemyStateMachine;
    }

}
