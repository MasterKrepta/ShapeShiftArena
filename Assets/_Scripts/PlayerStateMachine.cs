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


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponentInChildren<CharacterController>();
        InputReader = GetComponent<InputReader>();
        Anim = GetComponentInChildren<Animator>();
        renderer = GetComponentInChildren<Renderer>();
        currentState = new PlayerWerewolfState(this);
        SwitchState(currentState);
    }
    void OnAnimatorMove()
    {
        Debug.Log("onMove");
        transform.parent.rotation = Anim.rootRotation;
        transform.parent.position += Anim.deltaPosition;
    }



}
