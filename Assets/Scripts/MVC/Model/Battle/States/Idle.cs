using MVC.Model.Entity;
using Signals;
using UnityEngine;

namespace MVC.Model.Battle.States
{
    public class Idle:IState
    {
        private readonly StateMachine _sm;

        public Idle(StateMachine sm)
        {
            _sm = sm;
        }

        public void Enter()
        { }

        public void Exit()
        { }

        public void Update()
        { }

        public void OnSignal(ISignal signal)
        {
            if (signal is ActionSignal actionSignal)
            {
                if (actionSignal.GetAction == ActionType.StartFight)
                {
                    _sm.ChangeState<Preparing>();
                }

                if (actionSignal.GetAction == ActionType.Heal)
                {
                    var hero = EntityContainer.GetEntityByType<Hero>();
                    hero.Heal();
                }
            }
        }
    }
}