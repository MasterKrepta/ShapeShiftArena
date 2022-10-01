using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWizardState : PlayerBaseState
{
    private PlayerStateMachine playerStateMachine;
    public PlayerWizardState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
    }

    public override void Enter()
    {
        Debug.Log("Wizard Enter");
    }

    public override void Exit()
    {

    }

    public override void Tick(float deltaTime)
    {

    }
}
