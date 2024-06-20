using StatePattern.Enemy;
using StatePattern.Player;
using StatePattern.StateMachine;

public class CloneController : EnemyController
{
    private CloneStateMachine stateMachine;
    public int CloneCountLeft { get; private set; }
   public CloneController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
    {
        SetCloneCount(enemyScriptableObject.CloneCount);
        enemyView.SetController(this);       
        CreateStateMachine();
        stateMachine.ChangeState(States.IDLE);
    }
    public void SetCloneCount(int cloneCountToSet) => CloneCountLeft = cloneCountToSet;
    private void CreateStateMachine() => stateMachine = new CloneStateMachine(this);
    public override void UpdateEnemy()
    {
        if (currentState == EnemyState.DEACTIVE)
            return;

        stateMachine.Update();
    }
    public override void PlayerEnteredRange(PlayerController targetToSet)
    {
        base.PlayerEnteredRange(targetToSet);
        stateMachine.ChangeState(States.CHASING);
    }
    public override void PlayerExitedRange() => stateMachine.ChangeState(States.IDLE);
    public override void Die()
    {
        if (CloneCountLeft > 0)
            stateMachine.ChangeState(States.CLONING);
        base.Die();
    }
    public void Teleport() => stateMachine.ChangeState(States.TELEPORTING);
  
}
