using System;
using Signals;
using UnityEngine;

namespace MVC.Model.Entity
{
    public abstract class Entity : MonoBehaviour, IDamageable, IAttacking
    {
        protected Stats Stats;
        protected Stats OriginStats;
        public virtual void Attack(Entity target)
        {
            target.TakeDamage(this);
            EventBus.Invoke(new AttackSignal(this,target));
        }
        
        public Stats GetStats()
        {
            return Stats;
        }

        public virtual void Init(Stats stats)
        {
            Stats = stats;
            OriginStats = (Stats) stats.Clone();
        }
        public virtual void TakeDamage(Entity attackingEntity)
        {
            var damage = attackingEntity.GetStats().Damage;
            Stats.Health -= damage;
            if (Stats.Health == 0)
                Die();
        }

        protected void OnDisable()
        {
            LoadOriginStats();
        }
        
        protected virtual void Die()
        {
            LoadOriginStats();
            EventBus.Invoke(new ActionSignal(ActionType.BreakFight));
        }
        protected void LoadOriginStats()
        {
            Stats.Health = OriginStats.Health;
            Stats.Damage = OriginStats.Damage;
        }
    }
}