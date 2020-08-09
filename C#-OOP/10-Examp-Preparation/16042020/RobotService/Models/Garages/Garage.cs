using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int GarageCapacity = 10;
        private readonly Dictionary<string, IRobot> _robots;

        public Garage()
        {
            this._robots = new Dictionary<string, IRobot>(GarageCapacity);
        }

        public IReadOnlyDictionary<string, IRobot> Robots
        {
            get
            {
                return this._robots;
            }
        }

        public void Manufacture(IRobot robot)
        {
            if (this.Robots.Count == GarageCapacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.Robots.ContainsKey(robot.Name))
            {
                string msg = string.Format(ExceptionMessages.ExistingRobot, robot.Name);
                throw new ArgumentException(msg);
            }

            this._robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.Robots.ContainsKey(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            var currRobot = this.Robots[robotName];

            currRobot.IsBought = true;
            currRobot.Owner = ownerName;

            this._robots.Remove(robotName);
        }
    }
}