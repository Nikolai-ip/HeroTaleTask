using System;
using System.Collections;
using System.Collections.Generic;
using MVC.Model.Entity;
using Signals;
using UnityEngine;

namespace MVC.View
{
    public class AttackAnimator:MonoBehaviour
    {
        [SerializeField] private float _attackMoveDuration;
        [SerializeField] private float _attackAnimationDuration;
        [SerializeField] private float _dX;
        private Dictionary<Tuple<Type, Type>, Func<IEnumerator>> _animationCoroutineMap;
        private Entity _attacking;
        private Entity _damageable;
        private void Start()
        {
            EventBus.Subscribe<AttackSignal>(OnAttack);
            _animationCoroutineMap = new()
            {
                {new Tuple<Type, Type>(typeof(Hero),typeof(Enemy)), PlayHeroAttackAnimation},
                {new Tuple<Type, Type>(typeof(Enemy),typeof(Hero)), PlayEnemyAttackAnimation}
            };
        }

        private void OnAttack(AttackSignal signal)
        {
            _attacking = signal.Attacking;
            _damageable = signal.Damageable;
            var key = new Tuple<Type, Type>(_attacking.GetType(), _damageable.GetType());
            if (_animationCoroutineMap.TryGetValue(key, out var coroutine))
            {
                StartCoroutine(coroutine());
            }

        }

        private IEnumerator PlayHeroAttackAnimation()
        {
            var hero = _attacking as Hero;
            var enemy = _damageable as Enemy;
            Vector2 originPos = hero.transform.position;
            var ememyTr = enemy.transform;
            Vector2 target = Vector2.zero;
            if (hero.CurrentAttackType ==AttackType.Melee) 
                target = new Vector2(ememyTr.position.x+_dX,ememyTr.position.y);
            else if (hero.CurrentAttackType == AttackType.Far)
                target = new Vector2(originPos.x,ememyTr.position.y);
            yield return StartCoroutine(MoveTo(hero.transform,target));
            hero.GetComponent<Animator>().SetTrigger("Attack");
            yield return new WaitForSeconds(_attackAnimationDuration);
            yield return StartCoroutine(MoveTo(hero.transform, originPos));
            EventBus.Invoke(new AttackFinishedSignal());
        }

        private IEnumerator PlayEnemyAttackAnimation()
        {
            var enemy = _attacking as Enemy;
            var hero = _damageable as Hero;
            Vector2 originPos = enemy.transform.position;
            Vector2 target = hero.transform.position;
            yield return StartCoroutine(MoveTo(enemy.transform,target));
            yield return StartCoroutine(MoveTo(enemy.transform, originPos));
            EventBus.Invoke(new AttackFinishedSignal());
        }

        private IEnumerator MoveTo(Transform tr, Vector2 target)
        {
            float time = 0;
            Vector2 originPos = tr.position;
            var delay = new WaitForFixedUpdate();
            while (time < _attackMoveDuration)
            {
                time += Time.deltaTime;
                Vector2 newPos = Vector2.Lerp(originPos, target, time / _attackMoveDuration);
                tr.position = newPos;
                yield return delay;
            }
        }
    }
}