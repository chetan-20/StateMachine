
using StatePattern.Enemy;
using StatePattern.StateMachine;
using System.Collections.Generic;


public class GenericStateMachine<T> where T : EnemyController
{
    protected T Owner;
    protected IState currentState;
    protected Dictionary<States, IState> EStates = new Dictionary<States, IState>();

    protected void SetOwner()
    {
        foreach (IState state in EStates.Values)
        {
            state.Owner = Owner;
        }
    }
    public GenericStateMachine(T Owner)
    {
        this.Owner = Owner;
    }
    public void Update() => currentState?.Update();
    protected void ChangeState(IState newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState?.OnStateEnter();
    }

    public void ChangeState(States newState) => ChangeState(EStates[newState]);
}
