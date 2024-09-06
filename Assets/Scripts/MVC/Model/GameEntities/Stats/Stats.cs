using System;
using UnityEngine;

namespace MVC.Model.Entity
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Stats")]
    public class Stats : ScriptableObject,ICloneable
    {
        [SerializeField] private int health;
        [SerializeField] private int damage;


        public int Health
        {
            get => health;
            set
            {
                health = value;
                health = Math.Max(health, 0);
                StatsChanged?.Invoke(this);
            }
        }
        public event Action<Stats> StatsChanged;

        
        public int Damage
        {
            get => damage;
            set
            {
                damage = value;
                StatsChanged?.Invoke(this);
            }
        }

        public object Clone()
        {
            var clone = CreateInstance<Stats>();
            clone.Health = Health;
            clone.Damage = Damage;
            return clone;
        }
    }
}