using StatePattern.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePunchManStateMachine 
{
    private OnePunchManController Owner;
    private IState currentState;
    protected Dictionary<OnePunchManStates, IState> States = new Dictionary<OnePunchManStates, IState>();
    public OnePunchManStateMachine(OnePunchManController Owner)
    {
        this.Owner = Owner;
        CreateStates();
        SetOwner();
    }

    private void SetOwner()
    {
        foreach(IState states in States.Values)
        {
            states.Owner = Owner;
        }
    }

    private void CreateStates()
    {
        States.Add(OnePunchManStates.Idle, new IdleState(this));
        States.Add(OnePunchManStates.Rotating, new RotatingState(this));
        States.Add(OnePunchManStates.Shooting, new ShootingState(this));
    }
    public void Update() => currentState?.Update();
    private void ChangeState(IState newState)
    {
        currentState?.OnStateExit(); 
        currentState = newState;
        currentState?.OnStateEnter();
    }
    public void ChangeState(OnePunchManStates newState) => ChangeState(States[newState]);
}
public enum OnePunchManStates
{
    Idle,
    Rotating,
    Shooting
}
