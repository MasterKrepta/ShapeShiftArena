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
        //Debug.Log("werewolf enter");
        _stateMachine.renderer.material = _stateMachine.werewolf;
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

        HandleAnims(movement);


        Move(movement * _stateMachine.WerewolfMoveSpeed, deltaTime);
        _stateMachine.cc.Move(velocity * Time.deltaTime);


        FaceMovementDirection(movement, deltaTime);

    }
    private void HandleAnims(Vector3 movement)
    {
        if (movement != Vector3.zero)
            _stateMachine.Anim.SetBool("crawl", true);
        else
            _stateMachine.Anim.SetBool("crawl", false);


    }
    public override void Exit()
    {
        _stateMachine.InputReader.OnJumpEvent -= OnJump;
        _stateMachine.InputReader.OnAttackEvent -= Attack;
        _stateMachine.Anim.SetBool("crawl", false);

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
        //TODO pounce attack
        GetClosestTarget();

        //_stateMachine.cc.transform.LookAt(closestEnemy.transform.position);

        Vector3 lookDir = (closestEnemy.transform.position - _stateMachine.cc.transform.position).normalized;
        //FaceMovementDirection(lookDir, Time.deltaTime);
        _stateMachine.cc.transform.LookAt(closestEnemy.transform.position); //todo  this is a bug fix
        _stateMachine.Anim.SetTrigger("WerewolfAttack");
        //Debug.Log("Werewolf goes appshit");


    }


}
