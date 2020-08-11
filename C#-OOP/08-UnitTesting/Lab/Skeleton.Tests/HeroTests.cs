using Moq;
using NUnit.Framework;
using Skeleton;
using Skeleton.Tests.Files;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeoreShouldGainExoirienceIfTargetDies()
    {
        const int XP = 200;
        //var weapon = new FakeWeapon();
        //var target = new FakeTarget();

        //Using mocking
        var weapon = Mock.Of<IWeapon>(); //Return empty objeckt

        Mock<ITarget> target = new Mock<ITarget>();
        target.Setup(t => t.IsDead())
            .Returns(true);
        target.Setup(t => t.GiveExperience())
            .Returns(XP);

        var heroe = new Hero("Kiro", weapon);

        heroe.Attack(target.Object);

        Assert.That(heroe.Experience, Is.EqualTo(XP));
    }
}