using MVC.Model.Entity;
using MVC.View;
using UnityEngine;

namespace MVC.Model.Fabric
{
    public class HeroFabric:EntityFabric
    {
        [SerializeField] private EntityStatsUI _statsUI;
        public override Entity.Entity InitEntity()
        {
            var hero = FindObjectOfType<Hero>();
            var stats = Resources.Load<PlayerStats>("ScriptableObjects/Stats/PlayerStats");
            hero.Init(stats);
            _statsUI.Init(hero);
            return hero;
        }

        public override void Init()
        {
            EntityContainer.RegisterEntity(InitEntity());
        }
    }
}