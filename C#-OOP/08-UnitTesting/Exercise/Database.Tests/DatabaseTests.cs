using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database data;
        private const int MaxDataLengt = 16;
        private const int TestArrayLengt = 4;

        [SetUp]
        public void Setup()
        {
            int[] testArray = CreateTestData();

            this.data = new Database.Database(testArray);
        }

        private int[] CreateTestData()
        {
            int[] testArray = new int[TestArrayLengt];

            for (int i = 0; i < TestArrayLengt; i++)
            {
                testArray[i] = i + 1;
            }

            return testArray;
        }

        [Test]
        public void TestConstructorShoudWorkCorrectly()
        {
            int[] testArray = new int[] {1, 15, 16 ,20 };

            this.data = new Database.Database(testArray);

            int expectedCount = testArray.Length;
            int actualCount = this.data.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestConstructorShoudThworExceptionByInitialisingWithBigDataArray()
        {
            int[] testArray = new int[17];

            for (int i = 0; i < MaxDataLengt; i++)
            {
                testArray[i] = i + 1;
            }

            Assert.That(() => this.data = new Database.Database(testArray),
            Throws
            .InvalidOperationException
            .With
            .Message
            .EqualTo(("Array's capacity must be exactly 16 integers!")));

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

            Assert.AreEqual(expectedCount,actualCount);
        }

        [Test]
        public void TestAddShoudIncreaseCountWhenAddedSuccessfully()
        {
            this.data.Add(51);

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
        public void TestTryingToRemoveFromEmptyCollectionShoudThrowException()
        {
            this.data = new Database.Database();

            Assert.That(() =>
            {
                this.data.Remove();
            },
            Throws
            .InvalidOperationException
            .With
            .Message
            .EqualTo("The collection is empty!"));
        }

        [Test]
        public void TestFetchShoudReturnExactCopyOfCollectionData()
        {
            var expectedResult = CreateTestData();
            var currData = this.data.Fetch();

            Assert.AreEqual(expectedResult,currData);
        }
    }
}