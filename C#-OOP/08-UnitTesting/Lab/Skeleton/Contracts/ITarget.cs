namespace Skeleton.Contracts
{
    public interface ITarget
    {
        bool IsDead();

        int GiveExperience();

        void TakeAttack(int attackPoints);
    }
}