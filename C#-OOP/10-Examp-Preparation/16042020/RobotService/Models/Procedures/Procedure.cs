using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected ICollection<IRobot> Robots;

        public Procedure()
        {
            this.Robots = new List<IRobot>();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);
            foreach (var robot in Robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}