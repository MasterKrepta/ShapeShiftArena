using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private float verticalVelocity;
    private Vector3 impact;

    private Vector3 DampingVel;
    [SerializeField] float drag = 0.3f;
    [SerializeField] CharacterController controller;

    PlayerStateMachine _stateMachine;

    private void Start()
    {
        _stateMachine = GetComponent<PlayerStateMachine>();
        _stateMachine.InputReader.OnJumpEvent += HandleJump;
    }

    private void HandleJump()
    {
        Jump(50);
    }

    public Vector3 Movement => impact + Vector3.up * verticalVelocity;

    private void Update()
    {
        if (verticalVelocity < 0f) //&& controller.isGrounded)
        {
            //To stop random falling from small inclines do this instead of setting to zero
            verticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            Debug.Log("falling");
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        impact = Vector3.SmoothDamp(impact, Vector3.zero, ref DampingVel, drag);


    }

    internal void Reset()
    {
        impact = Vector3.zero;
        verticalVelocity = 0f;
    }

    public void AddForce(Vector3 force)
    {
        print(this.name + " got knockedback " + force);
        impact += force;


    }

    public void Jump(float Force)
    {
        Debug.Log("Jump");
        verticalVelocity += Force;
    }
}
