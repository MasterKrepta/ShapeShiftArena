using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayerBaseState : BaseState
{
    [SerializeField] public PlayerStateMachine _stateMachine;


    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        _stateMachine = playerStateMachine;
    }
    protected void Move(Vector3 motion, float deltaTime)
    {

        _stateMachine.cc.Move(motion * deltaTime);
    }

    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }


}
