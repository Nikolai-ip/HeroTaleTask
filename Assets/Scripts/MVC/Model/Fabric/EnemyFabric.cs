using MVC.Model.Entity;
using MVC.View;
using UnityEngine;

namespace MVC.Model.Fabric
{
    public class EnemyFabric:EntityFabric
    {
        [SerializeField] private EntityStatsUI _statsUI;
        public override void Init()
        {
            EntityContainer.RegisterEntity(InitEntity());
        }

        public override Entity.Entity InitEntity()
        {
            var enemy = FindObjectOfType<Enemy>();
            var stats = Resources.Load<EnemyStats>("ScriptableObjects/Stats/EnemyStats");
            enemy.Init(stats);
            _statsUI.Init(enemy);
            return enemy;
        }
    }
}