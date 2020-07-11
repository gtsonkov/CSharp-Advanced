namespace PlayersAndMonsters
{
    public class BladeKnight : DarkKnight
    {
        public BladeKnight(string username, int level) 
            : base(username, level)
        {

        }

        public override string ToString() => base.ToString();
    }
}