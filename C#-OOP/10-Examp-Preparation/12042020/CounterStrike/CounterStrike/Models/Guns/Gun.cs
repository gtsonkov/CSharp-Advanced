using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;
using System;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string _name;
        private int _bullets;

        public Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }

                this._name = value;
            }
        }

        public int BulletsCount
        {
            get
            {
                return this._bullets;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }

                this._bullets = value;
            }
        }

        public abstract int Fire();
    }
}