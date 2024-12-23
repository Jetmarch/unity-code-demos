using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class AttributeRepository : IHero
    {
        [SerializeField] private int _damage;
        [SerializeField] private int _health;
        [SerializeField] private int _armor;
        [SerializeField] private int _mana;
        [SerializeField] private int _speed;
        
        public int Damage
        {
            get => _damage; 
            set => _damage = Math.Max(0, value); 
        }
        public int Health 
        {
            get => _health; 
            set => _health = Math.Max(0, value); 
        }
        public int Armor 
        {
            get => _armor; 
            set => _armor = Math.Max(0, value); 
        }
        public int Mana 
        {
            get => _mana; 
            set => _mana = Math.Max(0, value); 
        }
        public int Speed 
        {
            get => _speed; 
            set => _speed = Math.Max(0, value); 
        }
    }
}