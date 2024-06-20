using StatePattern.StateMachine;

namespace StatePattern.Enemy
{
    public class HitManStateMachine : GenericStateMachine<HiitManController>
    {
        public HitManStateMachine(HiitManController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(StateMachine.States.IDLE, new IdleState<HiitManController>(this));
            States.Add(StateMachine.States.PATROLLING, new PatrollingState<HiitManController>(this));
            States.Add(StateMachine.States.CHASING, new ChasingState<HiitManController>(this));
            States.Add(StateMachine.States.SHOOTING, new ShootingState<HiitManController>(this));
            States.Add(StateMachine.States.TELEPORTING, new TeleportingState<HiitManController>(this));
        }
    }   
}
