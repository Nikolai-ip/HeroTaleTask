using UnityEngine;

namespace MVC.Model.Entity
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Stats/EnemyStats")]
    public class EnemyStats : Stats
    {
        [field: SerializeField] public int AppearingChance { get; set; }
    }
}