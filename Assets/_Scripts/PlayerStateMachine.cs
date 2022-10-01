using System.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine

{
    public CharacterController cc;
    public InputReader InputReader;
    public Transform MainCameraTransform;

    public PlayerBaseState currentState;
    public float WerewolfMoveSpeed = 5;
    public float RotationDamping = 30;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        InputReader = GetComponent<InputReader>();

        currentState = new PlayerWerewolfState(this);
        SwitchState(currentState);
    }




}
