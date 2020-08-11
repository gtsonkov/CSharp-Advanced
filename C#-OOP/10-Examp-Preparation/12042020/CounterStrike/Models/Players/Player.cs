using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string _userName;
        private int _health;
        private int _armor;
        private IGun _gun;

        public Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;

            if (health <= 0)
            {
                throw new AccessViolationException(ExceptionMessages.InvalidPlayerHealth);
            }

            if (armor <= 0)
            {
                throw new AccessViolationException(ExceptionMessages.InvalidPlayerArmor);
            }

            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }
        
        public string Username
        {
            get
            {
                return this._userName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                this._userName = value;
            }
        }

        public int Health
        {
            get
            {
                return this._health;
            }

            private set
            {
                this._health = value;
            }
        }

        public int Armor
        {
            get
            {
                return this._armor;
            }

            private set
            {

                this._armor = value;
            }
        }

        public IGun Gun
        {
            get
            {
                return this._gun;
            }

            private set
            {
                if (value == null)
                {
                    throw new AccessViolationException(ExceptionMessages.InvalidGun);
                }

                this._gun = value;
            }
        }

        public bool IsAlive => this.Health > 0;

        public void TakeDamage(int points)
        {
            if (this.Armor > 0)
            {
                this.Armor -= points;

                if (this.Armor < 0)
                {
                    this.Health -= Armor * (-1);
                    this.Armor = 0;
                }
            }
            else
            {
                if (this.Health - points > 0)
                {
                    this.Health -= points;
                }
                else
                {
                    this.Health = 0;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Username}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armor: {this.Armor}");
            sb.AppendLine($"--Gun: {this.Gun.Name}");

            return sb.ToString().Trim();
        }
    }
}