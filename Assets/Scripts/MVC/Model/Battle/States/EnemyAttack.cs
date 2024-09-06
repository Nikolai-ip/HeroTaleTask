using System;
using MVC.Controller;
using MVC.Model.Entity;
using Signals;
using UnityEngine;

namespace MVC.Model.Battle.States
{
    public class EnemyAttack : IState
    {
        private readonly StateMachine _sm;
        private float _attackDelay = 1;
        private float _time = 0;
        public EnemyAttack(StateMachine sm)
        {
            _sm = sm;
        }

        public void Enter()
        {
            EventBus.Subscribe<AttackFinishedSignal>(OnSignal);
            var selectedHero = EntityContainer.GetEntityByType<Hero>();
            var selectedEnemy = EntityContainer.GetEntityByType<Enemy>();
            selectedEnemy.Attack(selectedHero);
        }

        public void Exit()
        {
            EventBus.UnSubscribe<AttackFinishedSignal>(OnSignal);
        }

        public void Update()
        {

        }

        public void OnSignal(ISignal signal)
        {
            if (signal is AttackFinishedSignal)
            {
                _sm.ChangeState<Preparing>();
            }
        }
    }
}