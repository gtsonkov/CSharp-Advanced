using RobotService.Core.Contracts;
using RobotService.Models.Robots;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private List<string> _ValidRobotTypes;

        public Controller()
        {
            _ValidRobotTypes = new List<string>();

            foreach (var t in Assembly.GetAssembly(typeof(Robot)).GetTypes()
                .Where(ty => ty.IsSubclassOf(typeof(Robot))))
            {
                _ValidRobotTypes.Add(t.Name);
            }
        }

        public string Charge(string robotName, int procedureTime)
        {
            if (!this._ValidRobotTypes.Contains(robotName))
            {

            }

            return null;
        }

        public string Chip(string robotName, int procedureTime) => throw new System.NotImplementedException();

        public string History(string procedureType) => throw new System.NotImplementedException();

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime) => throw new System.NotImplementedException();

        public string Polish(string robotName, int procedureTime) => throw new System.NotImplementedException();

        public string Rest(string robotName, int procedureTime) => throw new System.NotImplementedException();

        public string Sell(string robotName, string ownerName) => throw new System.NotImplementedException();

        public string TechCheck(string robotName, int procedureTime) => throw new System.NotImplementedException();

        public string Work(string robotName, int procedureTime) => throw new System.NotImplementedException();
    }
}