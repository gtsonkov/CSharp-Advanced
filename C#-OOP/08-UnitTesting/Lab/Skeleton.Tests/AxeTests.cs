using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AxeSchoudLoseDurabilityAfterAttack()
    {
        Axe axe = new Axe(10, 5);
        Dummy target = new Dummy(100,400);

        axe.Attack(target);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(4));
    }

    [Test]
    public void AxeShoudThrowExceptionIfTryToAttackWithBrokenWeapon()
    {
        Axe axe = new Axe(10, 0);
        Dummy target = new Dummy(100, 400);

        Assert.That(() => axe.Attack(target),
            Throws
            .InvalidOperationException
            .With
            .Message
            .EqualTo("Axe is broken."));
    }
}