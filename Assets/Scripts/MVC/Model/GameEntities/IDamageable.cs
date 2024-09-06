namespace MVC.Model.Entity
{
    public interface IDamageable : IStats
    {
        public void TakeDamage(Entity attackingEntity);
    }
}