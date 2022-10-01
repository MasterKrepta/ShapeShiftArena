using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWerewolfState : PlayerBaseState
{
    private PlayerStateMachine playerStateMachine;

    public PlayerWerewolfState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
    }

    public override void Enter()
    {
        Debug.Log("werewolf enter");
    }
    public override void Tick(float deltaTime)
    {
        Debug.Log(" werewolf tick");
        Vector3 movement = CalculateMovement();


        Move(movement * _stateMachine.WerewolfMoveSpeed, deltaTime);
    }
    public override void Exit()
    {

    }

    private Vector3 CalculateMovement()
    {
        Vector3 fwd = _stateMachine.MainCameraTransform.forward;
        Vector3 right = _stateMachine.MainCameraTransform.right;

        fwd.y = 0f;
        right.y = 0f;

        fwd.Normalize();
        right.Normalize();

        return fwd * _stateMachine.InputReader.MovementValue.y +
                right * _stateMachine.InputReader.MovementValue.x;

    }


}
