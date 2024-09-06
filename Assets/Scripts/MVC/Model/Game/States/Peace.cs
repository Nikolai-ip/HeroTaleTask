using MVC.Model.Game.States;
using Signals;

namespace MVC.Model.GameStateMachine.States
{
    public class Peace : IState
    {
        private readonly GameStateMachine _sm;

        public Peace(GameStateMachine sm)
        {
            _sm = sm;
            EventBus.Subscribe<ActionSignal>(OnSignal);
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
                if (actionSignal.GetAction == ActionType.StartFight)
                    _sm.ChangeState<Fight>();
        }
    }
}