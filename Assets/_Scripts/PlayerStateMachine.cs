using System.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine

{
    public Material werewolf, vampire, wizard;
    public CharacterController cc;
    public InputReader InputReader;
    public Transform MainCameraTransform;
    public Renderer renderer;
    public Animator Anim;
    public PlayerBaseState currentState;
    public float WerewolfMoveSpeed = 6;
    public float VampireMoveSpeed = 3;
    public float WizardMoveSpeed = 1.5f;
    public float RotationDamping = 30;
    public EnemyHealth testTarget;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        InputReader = GetComponent<InputReader>();
        Anim = GetComponent<Animator>();
        renderer = GetComponentInChildren<Renderer>();
        currentState = new PlayerWerewolfState(this);
        SwitchState(currentState);
    }




}
