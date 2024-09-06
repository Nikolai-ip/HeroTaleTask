using MVC.Model.Battle.States;
using UnityEngine;

namespace MVC.Model.Battle
{
    public class BattleStateMachine : StateMachine
    {
        [SerializeField] private string currentState;
        public override void Init()
        {
            var preparingState = new Preparing(this);
            var attackState = new Attack(this);
            var enemyAttack = new EnemyAttack(this);
            var idle = new Idle(this);
            States.AddRange(new IState[] {idle, preparingState, attackState, enemyAttack });
            CurrentState = idle;
            CurrentState.Enter();
        }
        
    }
}