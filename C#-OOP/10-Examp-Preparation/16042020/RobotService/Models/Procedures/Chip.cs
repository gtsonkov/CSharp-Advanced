using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            if (robot.IsChipped)
            {
                throw new ArgumentException(ExceptionMessages.AlreadyChipped);
            }

            robot.Happiness -= 5;
            robot.IsChipped = true;

            this.Robots.Add(robot);
        }
    }
}