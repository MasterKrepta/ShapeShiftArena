using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWizardState : PlayerBaseState
{
    private PlayerStateMachine playerStateMachine;
    Vector3 velocity;
    public PlayerWizardState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
    }

    public override void Enter()
    {
        Debug.Log("Wizard Enter");
    }



    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();

        if (_stateMachine.cc.isGrounded)
        {
            //Todo fix this its inconsistant
            //velocity.y = -1;
            //To stop random falling from small inclines do this instead of setting to zero
            velocity.y = Physics.gravity.y * Time.deltaTime;
            //velocity.y = Physics.gravity.y * _stateMachine.cc.stepOffset * Time.deltaTime;
        }
        else
        {
            velocity.y += Physics.gravity.y * 2 * Time.deltaTime;
        }

        Move(movement * _stateMachine.WerewolfMoveSpeed, deltaTime);
        _stateMachine.cc.Move(velocity * Time.deltaTime);


        FaceMovementDirection(movement, deltaTime);
    }
    public override void Exit()
    {

    }
}
