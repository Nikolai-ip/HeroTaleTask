using System;
using EntryPoint;
using Signals;
using UnityEngine;

namespace MVC.View
{
    public class ConsoleView:InitializeableMono
    {
        public override void Init()
        {
            EventBus.Subscribe<StateChangedSignal>(OnStateChanged);
            EventBus.Subscribe<AttackTypeChangedSignal>(_ => Debug.Log(_));
        }

        private void OnStateChanged(StateChangedSignal signal)
        {
            Debug.Log(signal.GetStateType);
        }


    }
}