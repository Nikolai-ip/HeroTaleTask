using UnityEngine;

namespace EntryPoint
{
    public abstract class InitializeableMono:MonoBehaviour,IInitializable
    {
        public abstract void Init();
    }
}