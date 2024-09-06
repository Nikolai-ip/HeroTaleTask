using System;
using System.Collections.Generic;
using EntryPoint;
using MVC.Model.Battle.States;
using Signals;
using TMPro;
using UnityEngine;

namespace MVC.View
{
    public class IndicatorUI:InitializeableMono
    {
        [SerializeField] private PreparingIndicator _preparingIndicator;
        [SerializeField] private TextMeshProUGUI _attackIndicator;
        [SerializeField] private TextMeshProUGUI _enemyAttackIndicator;

        private Dictionary<Type, GameObject> _indicatorMap;
        public override void Init()
        {
            _indicatorMap = new()
            {
                { typeof(Preparing), _preparingIndicator.gameObject },
                { typeof(Attack), _attackIndicator.gameObject },
                {typeof(EnemyAttack),_enemyAttackIndicator.gameObject}
            };
            _preparingIndicator.Init();
            EventBus.Subscribe<StateChangedSignal>(OnStateChanged);
        }
        private void OnStateChanged(StateChangedSignal signal)
        {
            if (_indicatorMap.TryGetValue(signal.GetStateType, out var indicator))
            {
                DisableAllIndicators();
                indicator.SetActive(true);
            }
        }
        private void DisableAllIndicators()
        {
            foreach (var indicator in _indicatorMap.Values)
            {
                indicator.SetActive(false);
            }
        }


    }
}