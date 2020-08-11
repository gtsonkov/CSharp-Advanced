namespace Skeleton
{
    public interface ITarget
    {
        bool IsDead();

        int GiveExperience();

        void TakeAttack(int attackPoints);
    }
}