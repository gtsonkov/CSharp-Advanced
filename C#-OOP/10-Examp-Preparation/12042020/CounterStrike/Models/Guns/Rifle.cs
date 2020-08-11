namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int BulletsToFire = 10;

        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {

        }

        public override int Fire()
        {
            if ((this.BulletsCount - BulletsToFire) > 0)
            {
                this.BulletsCount -= BulletsToFire;

                return BulletsToFire;
            }

            return 0;
        }
    }
}