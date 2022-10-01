using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWerewolfState : PlayerBaseState
{
    private PlayerStateMachine playerStateMachine;
    public float jumpForce = 10;

    Vector3 velocity;


    public PlayerWerewolfState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
    }

    public override void Enter()
    {
        Debug.Log("werewolf enter");
        _stateMachine.InputReader.OnJumpEvent += OnJump;
        _stateMachine.InputReader.OnAttackEvent += Attack;

    }

    private void OnJump()
    {
        Jump(jumpForce);
    }

    public override void Tick(float deltaTime)
    {
        //Debug.Log(" werewolf tick");
        Vector3 movement = CalculateMovement();

        if (_stateMachine.cc.isGrounded)
        {
            //Todo fix this its inconsistant, probobly on the unity level
            //To stop random falling from small inclines do this instead of setting to zero
            velocity.y = Physics.gravity.y * Time.deltaTime;
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
        _stateMachine.InputReader.OnJumpEvent -= OnJump;
        _stateMachine.InputReader.OnAttackEvent -= Attack;
    }

    public void Jump(float Force)
    {

        // if (_stateMachine.cc.isGrounded)
        // {
        //     Debug.Log("jumpapplied");
        //     velocity.y += Force;
        //     //_stateMachine.rb.AddForce(Force * Vector3.up);
        // }
        velocity.y += Force;

    }

    public override void Attack()
    {
        Debug.Log("Werewolf goes appshit");
        _stateMachine.testTarget.TakeDamage(5);

    }
}
