using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private BaseState _currentState;

    private void Update()
    {
        _currentState?.Tick(Time.deltaTime);
    }
    public void SwitchState(BaseState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
    }


}
