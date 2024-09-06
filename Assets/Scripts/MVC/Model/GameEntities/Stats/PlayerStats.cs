using UnityEngine;

namespace MVC.Model.Entity
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Stats/PlayerStats")]
    public class PlayerStats : Stats
    {
        [field: SerializeField] public int Armor { get; set; }
        [field: SerializeField] public int PreparingTime { get; set; }
    }
}