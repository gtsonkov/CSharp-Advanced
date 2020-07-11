namespace PlayersAndMonsters
{
    public class Knight : Hero
    {
        public Knight(string username, int level) 
            : base(username, level)
        {

        }

        public override string ToString() => base.ToString();
    }
}