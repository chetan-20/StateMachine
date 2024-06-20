using StatePattern.Enemy;
using StatePattern.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy {
    public class CloneStateMachine : GenericStateMachine<CloneController>
    {
        public CloneStateMachine(CloneController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }
        private void CreateStates()
        {
            States.Add(StateMachine.States.IDLE, new IdleState<CloneController>(this));
            States.Add(StateMachine.States.PATROLLING, new PatrollingState<CloneController>(this));            
            States.Add(StateMachine.States.CHASING , new ChasingState<CloneController>(this));
            States.Add(StateMachine.States.SHOOTING, new ShootingState<CloneController>(this));
            States.Add(StateMachine.States.TELEPORTING, new TeleportingState<CloneController>(this));
            States.Add(StateMachine.States.CLONING, new CloneState<CloneController>(this));
        }
    }
}
