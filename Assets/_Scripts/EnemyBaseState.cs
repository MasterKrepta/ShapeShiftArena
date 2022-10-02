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
    public void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        if (movement == Vector3.zero) return;

        _stateMachine.cc.transform.rotation = Quaternion.Lerp(_stateMachine.cc.transform.rotation,
                                                            Quaternion.LookRotation(movement),
                                                            deltaTime * _stateMachine.RotationDamping);
    }
}
