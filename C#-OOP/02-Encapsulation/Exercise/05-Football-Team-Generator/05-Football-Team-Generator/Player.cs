using System;

namespace _05_Football_Team_Generator
{
    public class Player
    {
        private const int MIN_STRAS = 0;
        private const int MAX_STRAS = 0;

        private string _name;

        private int _endurance;
        private int _sprint;
        private int _dribble;
        private int _passing;
        private int _shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name 
        {
            get => this._name; 
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this._name = value;
            }
        }

        public int SkillLevel => (Endurance + Sprint + Dribble + Passing + Shooting) / 5;

        public int Endurance 
        { 
            get => this._endurance;
            
            set
            {
                try
                {
                    CheckValidValue(value, "Endurance");
                }
                catch (Exception ex)
                {

                    throw ex;
                }

                this._endurance = value;
            } 
        }

        public int Sprint
        {
            get => this._sprint;

            set
            {
                try
                {
                    CheckValidValue(value, "Sprint");
                }
                catch (Exception ex)
                {

                    throw ex;
                }

                this._sprint = value;
            }
        }

        public int Dribble
        {
            get => this._dribble;

            set
            {
                try
                {
                    CheckValidValue(value, "Dribble");
                }
                catch (Exception ex)
                {

                    throw ex;
                }

                this._dribble = value;
            }
        }

        public int Passing
        {
            get => this._passing;

            set
            {
                try
                {
                    CheckValidValue(value, "Passing");
                }
                catch (Exception ex)
                {

                    throw ex;
                }

                this._passing = value;
            }
        }

        public int Shooting
        {
            get => this._shooting;

            set
            {
                try
                {
                    CheckValidValue(value, "Shooting");
                }
                catch (Exception ex)
                {

                    throw ex;
                }

                this._shooting = value;
            }
        }

        private void CheckValidValue(int value, string name)
        {
            if (value < MIN_STRAS || value > MAX_STRAS)
            {
                throw new AggregateException($"{name} should be between {MIN_STRAS} and {MAX_STRAS}.");
            }
        }
    }
}