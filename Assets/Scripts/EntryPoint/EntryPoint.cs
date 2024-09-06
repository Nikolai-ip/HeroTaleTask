using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EntryPoint
{
    public class EntryPoint:MonoBehaviour
    {
        [SerializeField] private List<InitializeableMono> _initializeableObjects;
        [SerializeField] private bool _findInitMonos;

        private void OnValidate()
        {
            var initializeableMonos = FindObjectsOfType<InitializeableMono>().ToList();
            if (initializeableMonos.Count != _initializeableObjects.Count)
            {
                foreach (var initializeableMono in initializeableMonos)
                {
                    if (!_initializeableObjects.Contains(initializeableMono))
                    {
                        _initializeableObjects.Add(initializeableMono);
                    }
                }
            }
        }

        private void Awake()
        {
            foreach (var initializeableObject in _initializeableObjects)
            {
                initializeableObject.Init();
            }
        }
    }
}