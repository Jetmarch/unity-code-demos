namespace Game
{
    public interface IHero
    {
        public int Mana { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Speed { get; set; }
    }
}