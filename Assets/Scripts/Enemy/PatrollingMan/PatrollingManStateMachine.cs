
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class PatrollingManStateMachine : IStateMachine
    {
        private PatrollingManController Owner;
        private IState currentState;
        protected Dictionary<States, IState> EStates = new Dictionary<States, IState>();

        public PatrollingManStateMachine(PatrollingManController Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            EStates.Add(States.IDLE, new IdleState(this));
            EStates.Add(States.PATROLLING, new PatrollingState(this));
            EStates.Add(States.CHASING, new ChasingState(this));
            EStates.Add(States.SHOOTING, new ShootingState(this));
        }

        private void SetOwner()
        {
            foreach (IState state in EStates.Values)
            {
                state.Owner = Owner;
            }
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
}

