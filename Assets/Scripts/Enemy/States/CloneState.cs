using StatePattern.Main;
using StatePattern.StateMachine;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class CloneState<T> : IState where T : EnemyController
    {
        public EnemyController Owner { get;set; }
        private GenericStateMachine<T> stateMachine;
        public CloneState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;        
        public void OnStateEnter()
        {
            Clone();
            Clone();
        }
        public void OnStateExit() { }                     
        public void Update() { }
        private void Clone()
        {
            CloneController clone=GameService.Instance.EnemyService.CreateEnemy(Owner.Data) as CloneController;
            clone.SetCloneCount((Owner as CloneController).CloneCountLeft - 1);
            clone.Teleport();            
            GameService.Instance.EnemyService.AddEnemy(clone);
        }        
    }
}
