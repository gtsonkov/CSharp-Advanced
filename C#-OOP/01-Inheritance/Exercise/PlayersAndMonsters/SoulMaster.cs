namespace PlayersAndMonsters
{
    public class SoulMaster : DarkWizard
    {
        public SoulMaster(string username, int level) 
            : base(username, level)
        {
        }

        public override string ToString() => base.ToString();
    }
}