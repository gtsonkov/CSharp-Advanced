namespace PlayersAndMonsters
{
    public class DarkWizard : Wizard
    {
        public DarkWizard(string username, int level) 
            : base(username, level)
        {

        }

        public override string ToString() => base.ToString();
    }
}