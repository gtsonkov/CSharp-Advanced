using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase data;
        private const int MaxDataLengt = 16;
        private const int TestArrayLengt = 4;

        [SetUp]
        public void Setup()
        {
            Person[] testArray = CreateTestData();

            this.data = new ExtendedDatabase.ExtendedDatabase(testArray);
        }

        private Person[] CreateTestData()
        {
            Person[] testArray = new Person[TestArrayLengt];

            for (int i = 0; i < TestArrayLengt; i++)
            {
                int id = i + 1;
                string userName = "Pesho" + i.ToString();
                testArray[i] = new Person(id, userName);
            }

            return testArray;
        }

        [Test]
        public void TestConstructorShoudWorkCorrectly()
        {
            Person[] testArray = new Person[]
            { new Person(1,"Gosho"), new Person(2, "Pesho"), new Person(3,"Misho")};

            this.data = new ExtendedDatabase.ExtendedDatabase(testArray);

            int expectedCount = testArray.Length;
            int actualCount = this.data.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestConstructorShoudThworExceptionByInitialisingWithBigDataArray()
        {
            Person[] testArray = new Person[MaxDataLengt + 1];

            for (int i = 0; i < MaxDataLengt + 1; i++)
            {
                int age = i + 1;
                string name = "Pesho" + i.ToString();
            }

            Assert.That(() => this.data = new ExtendedDatabase.ExtendedDatabase(testArray),
            Throws
            .ArgumentException
            .With
            .Message
            .EqualTo(("Provided data length should be in range [0..16]!")));

            //Assert.Throws<InvalidOperationException>(() =>
            //{
            //    this.data = new Database(testArray);
            //});
        }

        [Test]
        public void TestChechIfCountReturnCorecttValue()
        {
            int expectedCount = TestArrayLengt;
            int actualCount = this.data.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestAddShoudIncreaseCountWhenAddedSuccessfully()
        {
            this.data.Add(new Person(25, "Kiro"));

            int expectedCount = TestArrayLengt + 1;
            int actualCount = this.data.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestRemoveFromCollectionShoudDecreaseCount()
        {
            this.data.Remove();

            int expectedCount = TestArrayLengt - 1;
            int actualCount = this.data.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestTryingToAddMoreThanAllowedCapacityShowdThrowException()
        {
            Person[] testArray = new Person[MaxDataLengt];

            for (int i = 0; i < MaxDataLengt; i++)
            {
                int id = i + 1;
                string userName = "Pesho" + i.ToString();
                testArray[i] = new Person(id, userName);
            }

            this.data = new ExtendedDatabase.ExtendedDatabase(testArray);

            Person testPerson = new Person(105, "Kiro");

            Assert.That(() => this.data.Add(testPerson),
            Throws
            .InvalidOperationException
            .With
            .Message
            .EqualTo(("Array's capacity must be exactly 16 integers!")));
        }

        [Test]
        public void TestTryingToAddgPersonWithExsistingNameShoudThrowException()
        {
            this.data = new ExtendedDatabase.ExtendedDatabase();

            Person pesho = new Person(1, "Pesho");
            Person pesho2 = new Person(2, "Pesho");
            this.data.Add(pesho);

            Assert.That(() =>
            {
                this.data.Add(pesho2);
            },
            Throws
            .InvalidOperationException
            .With
            .Message
            .EqualTo("There is already user with this username!"));
        }

        [Test]
        public void TestTryingToAddgPersonWithExsistingIdShoudThrowException()
        {
            this.data = new ExtendedDatabase.ExtendedDatabase();

            Person pesho = new Person(1, "Pesho");
            Person pesho2 = new Person(1, "Pesho2");
            this.data.Add(pesho);

            Assert.That(() =>
            {
                this.data.Add(pesho2);
            },
            Throws
            .InvalidOperationException
            .With
            .Message
            .EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void TestTryingToRemoveFromEmptyCollectionShoudThrowException()
        {
            this.data = new ExtendedDatabase.ExtendedDatabase();

            Assert.That(() =>
            {
                this.data.Remove();
            },
            Throws
            .InvalidOperationException);
        }

        [Test]
        public void TestTryigToFindPersonWithNullStringAsNameShoudThrowExeption()
        {
            string argument = null;

            Assert.That(() =>
            {
                this.data.FindByUsername(argument);
            },
            Throws
            .ArgumentNullException);
        }

        [Test]
        public void TestTryigToFindPersonWithEmptyStringAsNameShoudThrowExeption()
        {
            string argument = string.Empty;

            Assert.That(() =>
            {
                this.data.FindByUsername(argument);
            },
            Throws
            .ArgumentNullException);
        }

        [Test]
        public void TestTryigToFindPersonWhoNotExistInTheCollectionShoudThrowExeption()
        {
            string argument = "James";

            Assert.That(() =>
            {
                this.data.FindByUsername(argument);
            },
            Throws
            .InvalidOperationException
            .With
            .Message
            .EqualTo("No user is present by this username!"));
        }

        [Test]
        public void TestFindByUserNameShoudReturnPersonIfExist()
        {
            string argument = "Gosho";

            var expectedUser = new Person(this.data.Count + 1, argument);

            data.Add(expectedUser);

            var returnedUser = this.data.FindByUsername(argument);

            Assert.AreEqual(expectedUser, returnedUser);
        }

        [Test]
        public void TestTryToFindeUserWithNegativeIdShoudThrowException()
        {
            int argument = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                 this.data.FindById(argument);
            });
        }

        [Test]
        public void TestTryToFindeNotExistingIdThrowException()
        {
            int argument = 100;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.data.FindById(argument);
            });
        }

        [Test]
        public void TestShoudReturnTheRightPersonISurchedIdExist()
        {
            Person expectedPerson = new Person(101, "Gosho");

            this.data.Add(expectedPerson);

            var result = this.data.FindById(expectedPerson.Id);

            Assert.AreEqual(expectedPerson,result);
        }
    }
}
