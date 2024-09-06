using System;
using System.Collections.Generic;
using EntryPoint;
using MVC.Model.Game.States;
using MVC.Model.GameStateMachine.States;
using Signals;
using UnityEngine;

namespace MVC.View
{
    public class ButtonViewPanel:InitializeableMono
    {
        [SerializeField] private GameObject _peacePanel;
        [SerializeField] private GameObject _battlePanel;
        private Dictionary<Type, GameObject> _panelMap;
        public override void Init()
        {
            EventBus.Subscribe<StateChangedSignal>(OnStateChanged);
            _panelMap = new()
            {
                { typeof(Peace), _peacePanel },
                { typeof(Fight), _battlePanel }
            };
            DisableAllPanels();

        }

        private void OnStateChanged(StateChangedSignal signal)
        {
            if (_panelMap.TryGetValue(signal.GetStateType, out var panel))
            {
                DisableAllPanels();
                panel.SetActive(true);
            }
        }

        private void DisableAllPanels()
        {
            foreach (var panel in _panelMap.Values)
            {
                panel.SetActive(false);
            }
        }
    }
}