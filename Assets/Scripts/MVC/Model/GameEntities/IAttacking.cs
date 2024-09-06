namespace MVC.Model.Entity
{
    public interface IAttacking : IStats
    {
        public void Attack(Entity target);
    }
}