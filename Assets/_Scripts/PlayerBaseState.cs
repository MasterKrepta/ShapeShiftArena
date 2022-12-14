using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayerBaseState : BaseState
{
    [SerializeField] public PlayerStateMachine _stateMachine;
    protected EnemyHealth closestEnemy;
    float closestDist = float.PositiveInfinity;

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
    public void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        if (movement == Vector3.zero) return;

        _stateMachine.cc.transform.rotation = Quaternion.Lerp(_stateMachine.cc.transform.rotation,
                                                            Quaternion.LookRotation(movement),
                                                            deltaTime * _stateMachine.RotationDamping);
    }
    public Vector3 CalculateMovement()
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
    public void GetClosestTarget()
    {
        closestEnemy = null;
        closestDist = float.PositiveInfinity;
        EnemyHealth[] enemies;

        enemies = GameObject.FindObjectsOfType<EnemyHealth>();

        foreach (var e in enemies)
        {
            var testdist = Vector3.Distance(_stateMachine.cc.transform.position, e.transform.position);

            if (testdist < closestDist)
            {
                closestDist = testdist;
                closestEnemy = e;
            }
        }
    }
}
