namespace Skeleton.Tests.Files
{
    public class FakeTarget : ITarget
    {
        public const int DefaultExpirience = 100; 
        public int GiveExperience() => DefaultExpirience;
        public bool IsDead() => true;
        public void TakeAttack(int attackPoints)
        {

        }
    }
}