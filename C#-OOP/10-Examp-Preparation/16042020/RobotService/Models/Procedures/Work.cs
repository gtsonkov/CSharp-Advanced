using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;

namespace RobotService.Models.Procedures
{
    public class Work : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Energy -= 6;
            robot.Happiness += 12;

            this.Robots.Add(robot);
        }
    }
}