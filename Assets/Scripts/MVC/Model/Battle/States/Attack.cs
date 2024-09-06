using System.Collections;
using MVC.Model.Entity;
using Signals;
using UnityEngine;

namespace MVC.Model.Battle.States
{
    public class Attack : IState
    {
        private readonly StateMachine _sm;
        private Hero _selectedHero;
        private Enemy _selectedEnemy;
        private bool _isChangeAttackType;
        private float _changeAttackTypeDuration = 2;
        public Attack(StateMachine sm)
        {
            _sm = sm;
        }

        public void Enter()
        {
            _selectedHero = EntityContainer.GetEntityByType<Hero>();
            _selectedEnemy = EntityContainer.GetEntityByType<Enemy>();
            EventBus.Subscribe<AttackFinishedSignal>(OnSignal);
            _selectedHero.Attack(_selectedEnemy);

        }

        public void Exit()
        {
            _isChangeAttackType = false;
            EventBus.UnSubscribe<AttackFinishedSignal>(OnSignal);
        }

        public void Update()
        {
        }

        public void OnSignal(ISignal signal)
        {
            if (signal is ActionSignal actionSignal)
            {
                var action = actionSignal.GetAction;
                if (action == ActionType.ChangeAttackType)
                {
                    _isChangeAttackType = true;
                }
                if (action == ActionType.Run || action == ActionType.BreakFight)
                {
                    _sm.ChangeState<Idle>();
                }
            }

            if (signal is AttackFinishedSignal)
            {
                if (_isChangeAttackType)
                    _sm.StartCoroutine(ChangeAttackType());
                else
                {
                    _sm.ChangeState<EnemyAttack>();
                }
            }
        }

        private IEnumerator ChangeAttackType()
        {
            _selectedHero.ChangeAttackType();
            yield return new WaitForSeconds(_changeAttackTypeDuration);
            _sm.ChangeState<EnemyAttack>();
        }
    }
}