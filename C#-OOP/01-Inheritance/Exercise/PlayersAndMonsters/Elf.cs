namespace PlayersAndMonsters
{
    public class Elf : Hero
    {
        public Elf(string username, int level) 
            : base(username, level)
        {

        }

        public override string ToString() => base.ToString();
    }
}