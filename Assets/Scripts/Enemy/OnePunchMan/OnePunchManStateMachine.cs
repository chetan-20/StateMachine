using StatePattern.StateMachine;
using System.Collections.Generic;

namespace StatePattern.Enemy
{
    public class OnePunchManStateMachine : GenericStateMachine<OnePunchManController>
    {       
       

        public OnePunchManStateMachine(OnePunchManController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            EStates.Add(StateMachine.States.IDLE, new IdleState<OnePunchManController>(this));
            EStates.Add(StateMachine.States.ROTATING, new RotatingState<OnePunchManController>(this));
            EStates.Add(StateMachine.States.SHOOTING, new ShootingState<OnePunchManController>(this));
        }              
    }
}