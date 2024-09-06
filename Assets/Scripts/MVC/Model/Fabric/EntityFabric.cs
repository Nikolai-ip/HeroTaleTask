using EntryPoint;

namespace MVC.Model.Fabric
{
    public abstract class EntityFabric:InitializeableMono
    {
        public abstract Entity.Entity InitEntity();
    }
}