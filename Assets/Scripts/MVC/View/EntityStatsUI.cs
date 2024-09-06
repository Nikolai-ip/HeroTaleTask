using System;
using MVC.Model.Entity;
using TMPro;
using UnityEngine;

namespace MVC.View
{
    public class EntityStatsUI:MonoBehaviour
    {
        private TextMeshProUGUI _textUI;
        public void Init(Entity entity)
        {
            _textUI = GetComponent<TextMeshProUGUI>();
            entity.GetStats().StatsChanged += OnStatsChanged;
            OnStatsChanged(entity.GetStats());
        }
        private void OnStatsChanged(Stats stats)
        {
            _textUI.text = $"Health {stats.Health}\nDamage {stats.Damage}";
        }
    }
}