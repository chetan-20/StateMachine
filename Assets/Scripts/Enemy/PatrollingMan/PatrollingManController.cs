using StatePattern.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class PatrollingManController : EnemyController
    {
        private PatrollingManStateMachine stateMachine;
        public PatrollingManController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
        {
            enemyView.SetController(this);
            CreateStateMachine();
            stateMachine.ChangeState(States.IDLE);
        }
        private void CreateStateMachine() => stateMachine = new PatrollingManStateMachine(this);
        public override void PlayerEnteredRange(PlayerController targetToSet)
        {
            base.PlayerEnteredRange(targetToSet);
            stateMachine.ChangeState(States.CHASING);
        }        
        public override void PlayerExitedRange() => stateMachine.ChangeState(States.IDLE);
        public override void UpdateEnemy()
        {
            if (currentState == EnemyState.DEACTIVE)
                return;

            stateMachine.Update();
        }
        
    }
}
