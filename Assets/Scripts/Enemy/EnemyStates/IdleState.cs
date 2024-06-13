using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private OnePunchManStateMachine stateMachine;
    private float timer;
    public OnePunchManController Owner { get; set; }
    public IdleState(OnePunchManStateMachine stateMachine) => this.stateMachine = stateMachine;
    public void OnStateEnter() => ResetTimer();
    private void ResetTimer() => timer = Owner.Data.IdleTime;
    

    public void Update() 
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            stateMachine.ChangeState(OnePunchManStates.Rotating);
    }

    public void OnStateExit() => timer = 0;
}
