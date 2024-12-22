using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Hero : IHero
    {
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Mana { get; set; }
        
        public int Speed { get; set; }
    }
}