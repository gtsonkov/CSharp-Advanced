namespace PlayersAndMonsters
{
    public class Wizard : Hero
    {
        public Wizard(string username, int level) 
            : base(username, level)
        {

        }

        public override string ToString() => base.ToString();
    }
}