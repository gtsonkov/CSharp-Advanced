namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class PresentsTests
    {
        private const string FirstPresentName = "FirstPresent";
        private const double FirstPresentMagic = 1500;

        private Bag _bag;

        [SetUp]
        public void CreateBag()
        {
            this._bag = new Bag();

            Present firstPresent = new Present(FirstPresentName, FirstPresentMagic);
            this._bag.Create(firstPresent);

            for (int i = 0; i < 5; i++)
            {
                string name = "Present" + (i + 1);
                Present present = new Present(name, (i+100));

                this._bag.Create(present);
            }
        }

        [Test]
        public void CreatePresentShoudSuccessfulyAddPresentToTheBag()
        {
            var presentName = "test1";
            double magic = 100;
            Present testPresent = new Present(presentName,magic);
            string msg = this._bag.Create(testPresent);

            string expectedMsg = $"Successfully added present {testPresent.Name}.";

            Assert.AreEqual(expectedMsg,msg);
        }

        [Test]
        public void TryingToAddTheSameAPresentTwiceShoudThrowException()
        {
            Present testPresent = new Present("TestPresent",FirstPresentMagic);

            this._bag.Create(testPresent);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this._bag.Create(testPresent);
            });
        }

        [Test]
        public void TryingAddNULLPresentShoudThrowException()
        {
            Present testPresent = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                this._bag.Create(testPresent);
            });
        }

        [Test]
        public void TryingToRemoveExistingPresentShoudRetunTRUE()
        {
            Present testPresent = new Present("TestPresent", FirstPresentMagic);

            this._bag.Create(testPresent);

            bool result = this._bag.Remove(testPresent);

            Assert.IsTrue(result);
        }

        //To Remove
        [Test]
        public void TryingToRemoveUnexistingPresentShoudRetunFalse()
        {
            Present testPresent = new Present("TestPresent", FirstPresentMagic);

            bool result = this._bag.Remove(testPresent);

            Assert.IsFalse(result);
        }

        [Test]
        public void GetPresentWithLeastMagicShoudReturnTheRightPresent()
        {
            double magic = 1;
            Present expectedPresent = new Present("TestPresent", magic);

            this._bag.Create(expectedPresent);

            var result = this._bag.GetPresentWithLeastMagic();

            Assert.AreEqual(expectedPresent,result);
        }

        [Test]
        public void GetPresentByNameShoudRetunRightPresentIfExist()
        {
            string name = "TestPresent";
            double magic = 150;
            Present expectedPresent = new Present(name, magic);

            this._bag.Create(expectedPresent);

            var result = this._bag.GetPresent(name);

            Assert.AreEqual(expectedPresent, result);
        }

        [Test]
        public void GetPresentShoudReturnIReadOnlyCollectionWithPresents()
        {
            var result = this._bag.GetPresents();

            Assert.That(result is IReadOnlyCollection<Present>);
        }
    }
}