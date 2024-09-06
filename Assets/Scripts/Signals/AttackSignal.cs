using MVC.Model.Entity;

namespace Signals
{
    public class AttackSignal:ISignal
    {
        public Entity Attacking { get; }

        public Entity Damageable { get; }

        public AttackSignal(Entity attacking, Entity damageable)
        {
            Attacking = attacking;
            Damageable = damageable;
        }
    }
}