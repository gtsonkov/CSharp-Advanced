namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class ComputerTests
    {
        private Computer _testComputer;

        [SetUp]
        public void Setup()
        {
            this._testComputer = new Computer("TestComputer");
        }

        [Test]
        public void AsserThahConstructorWorkPropertly()
        {
            string name = "Computer";
            Computer computer = new Computer(name);

            Assert.That(computer.Name == name);
        }

        //TODO Test Assert Right name and Test Assert object not null

        [Test]
        public void TryigToCreateComputerWithNullNameShoudThwowException()
        {
            string name = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Computer computer = new Computer(name);
            });
        }

        [Test]
        public void MethodAddPartShoudAddGivenPart()
        {
            string partName = "Ram";
            decimal partPrice = 12.01M;
            Part testPart = new Part(partName, partPrice);

            this._testComputer.AddPart(testPart);
        }

        [Test]
        public void TryigToAddNullPartShoudThrwoException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this._testComputer.AddPart(null);
            });
        }

        [Test]
        public void MethodPartsShoudReturnCollectionOfParts()
        {
            string part1Name = "CPU";
            decimal price1 = 20.55M;

            string part2Name = "RAM";
            decimal price2 = 10.44M;

            Part part1 = new Part(part1Name, price1);
            Part part2 = new Part(part2Name, price2);

            this._testComputer.AddPart(part1);
            this._testComputer.AddPart(part2);

            var result = this._testComputer.Parts;

            Assert.That(result.Contains(part1) && result.Contains(part2));

        }

        //TO DO Test That Assert Returnet Collection is IredOnlyCollection

        [Test]
        public void MethodTotalPriceShoudReturnCorrectSum()
        {
            string part1Name = "CPU";
            decimal price1 = 20.55M;

            string part2Name = "RAM";
            decimal price2 = 10.44M;

            Part part1 = new Part(part1Name, price1);
            Part part2 = new Part(part2Name, price2);

            this._testComputer.AddPart(part1);
            this._testComputer.AddPart(part2);

            decimal expectedResult = price1 + price2;

            decimal currentTotalPrice = this._testComputer.TotalPrice;

            Assert.AreEqual(expectedResult,currentTotalPrice);
        }

        [Test]
        public void MethodGetPartShoudReturnTheFirstPartWithGivenNameIfExist()
        {
            string part1Name = "CPU";
            decimal price1 = 20.55M;

            string part2Name = "RAM";
            decimal price2 = 10.44M;

            Part expectedPart = new Part(part1Name, price1);
            Part part2 = new Part(part2Name, price2);

            this._testComputer.AddPart(expectedPart);
            this._testComputer.AddPart(part2);

            var result = this._testComputer.GetPart(part1Name);

            Assert.AreEqual(expectedPart,result);
        }

        //ReturnNull If Part Not Exist

        [Test]
        public void MethodRemovePartShoudRemoveTheGivenPartFromCollection()
        {
            string part1Name = "CPU";
            decimal price1 = 20.55M;

            string part2Name = "RAM";
            decimal price2 = 10.44M;

            Part part1 = new Part(part1Name, price1);
            Part part2 = new Part(part2Name, price2);

            this._testComputer.AddPart(part1);
            this._testComputer.AddPart(part2);

            bool result = this._testComputer.RemovePart(part2);

            Assert.IsTrue(result);
        }
    }
}