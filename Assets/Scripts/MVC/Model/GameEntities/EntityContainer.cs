using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Model.Entity
{
    public static class EntityContainer
    {
        private static Dictionary<Type,List<Entity>>  Entities = new();

        public static void RegisterEntity(Entity entity)
        {
            var key = entity.GetType();
            if (Entities.ContainsKey(key))
            {
                Entities[key].Add(entity);
            }
            else
            {
                Entities.Add(key, new List<Entity>(){entity});
            }
        }

        public static T GetEntityByType<T>() where T:Entity
        {
            return (T)GetEntitiesByType<T>().First();
        }
        public static List<Entity> GetEntitiesByType<T>()
        {
            if (Entities.TryGetValue(typeof(T), out var result))
            {
                return result;
            }

            throw new Exception($"Entities with type {typeof(T)} not found");

        }
    }
}