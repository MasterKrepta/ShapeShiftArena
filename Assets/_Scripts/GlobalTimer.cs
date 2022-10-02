using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimer : MonoBehaviour
{
    public static GlobalTimer Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
    }
    [SerializeField] float MaxTime = 10;

    [SerializeField] PlayerStateMachine _stateMachine;

    public int randomState, currentState;
    float nextTimeChange;

    // Start is called before the first frame update
    void Start()
    {
        _stateMachine = FindObjectOfType<PlayerStateMachine>();
        currentState = 0;
        SetNextTime();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextTimeChange)
        {
            switch (randomState)
            {
                //TODO figure out a good way to prevent getting the same state
                case 0:
                    _stateMachine.SwitchState(new PlayerWerewolfState(_stateMachine));
                    break;
                case 1:
                    _stateMachine.SwitchState(new PlayerVampireState(_stateMachine));
                    break;
                case 2:
                    _stateMachine.SwitchState(new PlayerWizardState(_stateMachine));
                    break;
            }
            SetNextTime();
        }
    }

    void SetNextTime()
    {
        while (randomState == currentState)
        {
            randomState = Random.Range(0, 3);
        }
        currentState = randomState;
        nextTimeChange = Time.time + MaxTime;
    }
}
