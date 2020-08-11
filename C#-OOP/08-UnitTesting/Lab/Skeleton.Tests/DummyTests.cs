using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummySchoudLoseHealthIfAttacked()
    {
        var dummy = new Dummy(100,200);

        dummy.TakeAttack(50);

        Assert.That(dummy.Health, Is.EqualTo(50));
    }

    [Test]
    public void DummySchoudThrowExceptionlthIfAttackedWhenHealtIsZeroe()
    {
        var dummy = new Dummy(0,200);

        //dummy.TakeAttack(50);

        Assert.That(() => dummy.TakeAttack(50), 
            Throws
            .InvalidOperationException
            .With
            .Message
            .EqualTo("Dummy is dead."));
    }

    [Test]
    public void DummySchoudGiveExperienceIfDead()
    {
        var dummy = new Dummy(0, 200);

        //dummy.TakeAttack(50);

        int expierence = dummy.GiveExperience();

        Assert.That(expierence, Is.EqualTo(200));
    }

    [Test]
    public void DummySchoudNotGiveExperienceIfAlive()
    {
        var dummy = new Dummy(100, 200);

        Assert.That(() => dummy.GiveExperience(),
            Throws
            .InvalidOperationException
            .With
            .Message
            .EqualTo("Target is not dead."));
    }
}