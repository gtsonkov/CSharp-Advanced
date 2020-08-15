using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private List<string> _validRobotTypes;
        private Garage _garage;
        private readonly Dictionary<string, IProcedure> _procedures;

        public Controller()
        {
            this._garage = new Garage();

            this._validRobotTypes = new List<string>();

            this._procedures = new Dictionary<string, IProcedure>();

            SeedRobotTypes();
            SeedProcedures();
        }

        public string Charge(string robotName, int procedureTime)
        {
            string procedureName = "Charge";

            if (!CheckRobotExist(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            IRobot currRobot = this._garage.Robots[robotName];

            this._procedures[procedureName.ToLower()].DoService(currRobot, procedureTime);

            return $"{currRobot.Name} had charge procedure";
        }

        public string Chip(string robotName, int procedureTime)
        {
            string procedureName = "Chip";

            if (!CheckRobotExist(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            IRobot currRobot = this._garage.Robots[robotName];

            this._procedures[procedureName.ToLower()].DoService(currRobot, procedureTime);

            return $"{currRobot.Name} had chip procedure";
        }

        public string History(string procedureType)
        {
            return this._procedures[procedureType.ToLower()].History();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if (!this._validRobotTypes.Contains(robotType))
            {
                string msg = string.Format(ExceptionMessages.InvalidRobotType, robotType);

                throw new ArgumentException(msg);
            }

            IRobot currentRobot = null;

            switch (robotType)
            {
                case "HouseholdRobot":
                    currentRobot = new HouseholdRobot(name, energy, happiness, procedureTime);

                    break;

                case "WalkerRobot":
                    currentRobot = new WalkerRobot(name, energy, happiness, procedureTime);

                    break;

                case "PetRobot":
                    currentRobot = new PetRobot(name, energy, happiness, procedureTime);

                    break;
            }

            this._garage.Manufacture(currentRobot);

            return $"Robot {currentRobot.Name} registered successfully";
        }

        public string Polish(string robotName, int procedureTime)
        {
            string procedureName = "Polish";

            if (!CheckRobotExist(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            IRobot currRobot = this._garage.Robots[robotName];

            this._procedures[procedureName.ToLower()].DoService(currRobot, procedureTime);

            return $"{currRobot.Name} had polish procedure";
        }

        public string Rest(string robotName, int procedureTime)
        {
            string procedureName = "Rest";

            if (!CheckRobotExist(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            IRobot currRobot = this._garage.Robots[robotName];

            this._procedures[procedureName.ToLower()].DoService(currRobot, procedureTime);

            return $"{currRobot.Name} had rest procedure";
        }

        public string Sell(string robotName, string ownerName)
        {
            if (!CheckRobotExist(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            bool currRobot = this._garage.Robots[robotName].IsChipped;

            this._garage.Sell(robotName, ownerName);

            if (currRobot)
            {
                return $"{ownerName} bought robot with chip";
            }

            return $"{ownerName} bought robot without chip";
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            string procedureName = "TechCheck";

            if (!CheckRobotExist(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            IRobot currRobot = this._garage.Robots[robotName];

            this._procedures[procedureName.ToLower()].DoService(currRobot, procedureTime);

            return $"{currRobot.Name} had tech check procedure";
        }

        public string Work(string robotName, int procedureTime)
        {
            string procedureName = "Work";

            if (!CheckRobotExist(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            IRobot currRobot = this._garage.Robots[robotName];

            this._procedures[procedureName.ToLower()].DoService(currRobot, procedureTime);

            return $"{currRobot.Name} was working for {procedureTime} hours";
        }

        private bool CheckRobotExist(string robotName)
        {
            if (this._garage.Robots.ContainsKey(robotName))
            {
                return true;
            }

            return false;
        }

        private void SeedProcedures()
        {
            foreach (var p in Assembly.GetAssembly(typeof(Procedure)).GetTypes()
                .Where(ty => ty.IsSubclassOf(typeof(Procedure))))
            {
                string name = p.Name.ToLower();
                _procedures.Add(name, null);

                switch (p.Name)
                {
                    case "Charge":
                        IProcedure charge = new Charge();
                        _procedures[name] = charge;
                        break;
                    case "Chip":
                        IProcedure chip = new Chip();
                        _procedures[name] = chip;
                        break;
                    case "Polish":
                        IProcedure polish = new Polish();
                        _procedures[name] = polish;
                        break;
                    case "Rest":
                        IProcedure rest = new Rest();
                        _procedures[name] = rest;
                        break;
                    case "TechCheck":
                        IProcedure techCheck = new TechCheck();
                        _procedures[name] = techCheck;
                        break;
                    case "Work":
                        IProcedure work = new Work();
                        _procedures[name] = work;
                        break;
                }
            }
        }

        private void SeedRobotTypes()
        {
            foreach (var t in Assembly.GetAssembly(typeof(Robot)).GetTypes()
                .Where(ty => ty.IsSubclassOf(typeof(Robot))))
            {
                _validRobotTypes.Add(t.Name);
            }
        }
    }
}