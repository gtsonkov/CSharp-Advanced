namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private const int Capacity = 10;
        private const string FirsRobotName = "Kiro";
        private const int FirsRobotMaxBattery = 20;

        private RobotManager robotManger;


        [SetUp]
        public void InitRobotManager()
        {
            robotManger = new RobotManager(Capacity);

            Robot firstRobot = new Robot(FirsRobotName, FirsRobotMaxBattery);

            robotManger.Add(firstRobot);

            for (int i = 0; i < Capacity - 2; i++)
            {
                string name = "TestRobot" + i;
                Robot currRobot = new Robot(name, i + 10);
                robotManger.Add(currRobot);
            }
        }

        [Test]
        public void RobotShoudBeSuccessfulCreated()
        {
            Robot testRobot = new Robot("Test", 100);

            Assert.That(testRobot != null);
        }

        [Test]
        public void RobotNameShoudBeSetSucckesfully()
        {
            string robotName = "Test";
            Robot testRobot = new Robot(robotName, 100);

            Assert.AreEqual(robotName, testRobot.Name);
        }

        [Test]
        public void RobotMaxBatteryShoudBeSetSucckesfully()
        {
            string robotName = "Test";
            int maxBattery = 100;
            Robot testRobot = new Robot(robotName, maxBattery);

            Assert.AreEqual(maxBattery, testRobot.MaximumBattery);
        }

        [Test]
        public void RobotManagerShoudBeInitializeWithRightCapacity()
        {
            int capacity = 20;

            RobotManager testManager = new RobotManager(capacity);

            Assert.AreEqual(capacity, testManager.Capacity);
        }

        [Test]
        public void RobotManagerShoudThrowExceptionIfTryToSetNegativeCapacity()
        {
            int capacity = -1;

            Assert.That(() =>
            {
                RobotManager testManager = new RobotManager(capacity);
            },
            Throws
            .ArgumentException
            .With
            .Message
            .EqualTo("Invalid capacity!")
            );
        }

        [Test]
        public void AddRobotShoudIncreaseCount()
        {
            int countBeforAdd = this.robotManger.Count;

            Robot testRobot = new Robot("Pesho", 50);

            this.robotManger.Add(testRobot);

            int expectedCount = countBeforAdd + 1;

            Assert.AreEqual(expectedCount, this.robotManger.Count);
        }

        [Test]
        public void AddRobotWithExistingNameShoudThrowException()
        {
            Robot testRobot = new Robot(FirsRobotName, FirsRobotMaxBattery);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManger.Add(testRobot);
            });
        }

        [Test]
        public void TryToAddMoreRobotsThanCapacityShoudThrowException()
        {
            Robot testRobot1 = new Robot("Anton", FirsRobotMaxBattery);
            Robot testRobot2 = new Robot("Miro", FirsRobotMaxBattery);

            this.robotManger.Add(testRobot1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManger.Add(testRobot2);
            });
        }

        [Test]
        public void RemoveingExistingRobotShoudDecreaseCount()
        {
            int countBeforRemoving = this.robotManger.Count;

            this.robotManger.Remove(FirsRobotName);

            int expectedCount = countBeforRemoving - 1;

            Assert.AreEqual(expectedCount, this.robotManger.Count);
        }

        [Test]
        public void TryingToRemoveUnexistingRobotShoudThrowExeption()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManger.Remove("Peter");
            });
        }

        [Test]
        public void AfterWorkingRobotShoudHaveLessEnergy()
        {
            string robotName = "Misho";
            int maxBaterry = 100;
            Robot testRobot = new Robot(robotName, maxBaterry);

            this.robotManger.Add(testRobot);

            string job = "GoToPark";
            int jobEnergyUstage = 60;

            this.robotManger.Work(robotName, job, jobEnergyUstage);

            int expectedEnergy = maxBaterry - jobEnergyUstage;

            Assert.AreEqual(expectedEnergy, testRobot.Battery);
        }

        [Test]
        public void TryingToWorkWithUnexistingRobotShoudThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                string robotName = "Owen";
                string job = "something";
                int jobEnergy = 10;
                this.robotManger.Work(robotName, job, jobEnergy);
            });
        }

        [Test]
        public void ShoudThrowExeptionWennTryingToWorkWithoutEnoughtEnergy()
        {
            string robotName = "Misho";
            int maxBaterry = 20;
            Robot testRobot = new Robot(robotName, maxBaterry);

            this.robotManger.Add(testRobot);

            string job = "GoToPark";
            int jobEnergyUstage = 60;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManger.Work(robotName,job,jobEnergyUstage);
            });

        }
    }
}