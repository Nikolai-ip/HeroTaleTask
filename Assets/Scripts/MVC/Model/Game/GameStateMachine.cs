using MVC.Model.Battle;
using MVC.Model.Game.States;
using MVC.Model.GameStateMachine.States;

namespace MVC.Model.GameStateMachine
{
    public class GameStateMachine : StateMachine
    {
        public override void Init()
        {
            var fightState = new Fight(this,FindObjectOfType<BattleStateMachine>());
            var peaceState = new Peace(this);
            States.AddRange(new IState[] { fightState, peaceState });
            CurrentState = peaceState;
            CurrentState.Enter();
        }
    }
}