using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVampireState : PlayerBaseState
{
    private PlayerStateMachine playerStateMachine;
    public PlayerVampireState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
    }

    public override void Enter()
    {
        Debug.Log("Vampire Enter");
    }

    public override void Exit()
    {

    }

    public override void Tick(float deltaTime)
    {

    }


}
