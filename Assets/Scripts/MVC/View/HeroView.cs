using System.Collections.Generic;
using EntryPoint;
using MVC.Model.Entity;
using Signals;
using UnityEngine;

namespace MVC.View
{
    public class HeroView:InitializeableMono
    {
        private Animator _animator;

        enum AnimLayer
        {
            Knight,
            Archer
        }
        private Dictionary<AttackType, AnimLayer> _animatorLayerMap = new()
        {
            { AttackType.Melee, AnimLayer.Knight},
            { AttackType.Far, AnimLayer.Archer}
        };
        public override void Init()
        {
            _animator = GetComponent<Animator>();
            EventBus.Subscribe<AttackTypeChangedSignal>(OnAttackTypeChanged);
        }

        private void OnAttackTypeChanged(AttackTypeChangedSignal signal)
        {
            DisableAllLayers();
            _animator.SetLayerWeight((int)_animatorLayerMap[signal.GetAttackType],1);
        }

        private void DisableAllLayers()
        {
            foreach (var animLayer in _animatorLayerMap.Values)
            {
                _animator.SetLayerWeight((int)animLayer, 0);
            }
        }
    }
}