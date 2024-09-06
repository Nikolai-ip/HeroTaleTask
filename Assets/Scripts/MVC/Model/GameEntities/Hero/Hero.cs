using System;
using Signals;
using UnityEngine;

namespace MVC.Model.Entity
{
    public class Hero : Entity
    {
        private AttackType _currentAttackType;
        public AttackType CurrentAttackType
        {
            get => _currentAttackType;
            private set
            {
                _currentAttackType = value;  
                EventBus.Invoke(new AttackTypeChangedSignal(value));
            }
        }
        
        public void ChangeAttackType()
        {
            int index = (int)_currentAttackType;
            index = (index + 1) % 2;
            CurrentAttackType = (AttackType)index;
        }
        public void Heal(int health = 2)
        {
            Stats.Health += health;
            Stats.Health = Math.Min(Stats.Health, OriginStats.Health);
        }
        public override void Init(Stats stats)
        {
            base.Init(stats);
            CurrentAttackType = AttackType.Melee;
        }


    }
}