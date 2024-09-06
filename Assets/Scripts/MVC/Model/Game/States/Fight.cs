using MVC.Model.Battle;
using MVC.Model.GameStateMachine.States;
using Signals;
using UnityEngine;

namespace MVC.Model.Game.States
{
    public class Fight : IState
    {
        private BattleStateMachine _battleStateMachine;
        private readonly GameStateMachine.GameStateMachine _sm;

        public Fight(GameStateMachine.GameStateMachine sm,BattleStateMachine battleSm)
        {
            _sm = sm;
            EventBus.Subscribe<ActionSignal>(OnSignal);
            _battleStateMachine = battleSm;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }

        public void OnSignal(ISignal signal)
        {
            if (signal is ActionSignal actionSignal)
            {
                if (actionSignal.GetAction == ActionType.Run || actionSignal.GetAction == ActionType.BreakFight )
                    _sm.ChangeState<Peace>();
            }

            _battleStateMachine.CurrentState.OnSignal(signal);
        }
    }
}