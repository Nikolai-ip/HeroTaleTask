using System.Collections;
using MVC.Model.Entity;
using Signals;
using UnityEngine;

namespace MVC.Model.Battle.States
{
    public class Preparing : IState
    {
        private readonly StateMachine _sm;
        private Hero _currentHero;
        private float _time = 0;
        private bool _isStop;
        private float _stopTime = 2;
        private Coroutine _stopTimer;
        public Preparing(StateMachine sm)
        {
            _sm = sm;
        }

        public void Enter()
        {
            _currentHero = EntityContainer.GetEntityByType<Hero>();
            _time = 0;

        }

        public void Exit()
        {
            _time = 0;
            if (_stopTimer != null)
                _sm.StopCoroutine(_stopTimer);
            else
                _isStop = false;
        }

        public void Update()
        {
            if (!_isStop)
            {
                float preparingTime = ((PlayerStats)_currentHero.GetStats()).PreparingTime;
                _time += Time.deltaTime;
                EventBus.Invoke(new PreparingTimeSignal(preparingTime-_time));
                if (_time > preparingTime)
                {
                    _sm.ChangeState<Attack>();
                }
            }
        }

        private IEnumerator StopTimerCoroutine()
        {
            _isStop = true;
            yield return new WaitForSeconds(_stopTime);
            _isStop = false;
        }
        public void OnSignal(ISignal signal)
        {
            if (signal is ActionSignal actionSignal)
            {
                var action = actionSignal.GetAction;
                if (action == ActionType.ChangeAttackType)
                {
                    _currentHero.ChangeAttackType();
                    _stopTimer = _sm.StartCoroutine(StopTimerCoroutine());
                }

                if (action == ActionType.Run || action == ActionType.BreakFight)
                {
                    _sm.ChangeState<Idle>();
                }
            }

        }
    }
}