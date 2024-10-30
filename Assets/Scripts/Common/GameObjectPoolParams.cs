using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class GameObjectPoolParams
    {
        public int InitialCount => _initialCount;
        public Transform Container => _container;
        public GameObject Prefab => _prefab;
        public bool IsInstatiateOnEmpty => _isInstatiateOnEmpty;

        [SerializeField] private int _initialCount;
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private bool _isInstatiateOnEmpty;
    }
}