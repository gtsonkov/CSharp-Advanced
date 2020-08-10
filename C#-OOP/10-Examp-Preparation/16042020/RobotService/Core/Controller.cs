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
            ;
        }

        public string Charge(string robotName, int procedureTime)
        {
            string procedureName = "Charge";

            if (!CheckRobotExist(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot,robotName);
                throw new ArgumentException(msg);
            }

            IRobot currRobot = this._garage.Robots[robotName];

            this._procedures[procedureName].DoService(currRobot, procedureTime);

            return $"{currRobot.Name} had charge procedure";
        }

        public string Chip(string robotName, int procedureTime)
        {
            if (!CheckRobotExist(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            IRobot currRobot = this._garage.Robots[robotName];

            throw new NotImplementedException();
        }

        public string History(string procedureType) => throw new System.NotImplementedException();

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if (!this._validRobotTypes.Contains(robotType))
            {
                string msg = string.Format(ExceptionMessages.InvalidRobotType,robotType);

                throw new ArgumentException(msg);
            }

            IRobot currentRobot = null;

            switch (robotType)
            {
                case "HouseholdRobot":
                    currentRobot = new HouseholdRobot(name,energy,happiness,procedureTime);

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
            if (!CheckRobotExist(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            throw new NotImplementedException();
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!CheckRobotExist(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            throw new NotImplementedException();
        }

        public string Sell(string robotName, string ownerName)
        {
            if (!CheckRobotExist(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            throw new NotImplementedException();
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!CheckRobotExist(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            throw new NotImplementedException();
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!CheckRobotExist(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            throw new NotImplementedException();
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
                _procedures.Add(p.Name, null);

                switch (p.Name)
                {
                    case "Charge":
                        IProcedure charge = new Charge();
                        _procedures[p.Name] = charge;
                        break;
                    case "Chip":
                        IProcedure chip = new Chip();
                        _procedures[p.Name] = chip;
                        break;
                    case "Polish":
                        IProcedure polish = new Polish();
                        _procedures[p.Name] = polish;
                        break;
                    case "Rest":
                        IProcedure rest = new Rest();
                        _procedures[p.Name] = rest;
                        break;
                    case "TechCheck":
                        IProcedure techCheck = new TechCheck();
                        _procedures[p.Name] = techCheck;
                        break;
                    case "Work":
                        IProcedure work = new Work();
                        _procedures[p.Name] = work;
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