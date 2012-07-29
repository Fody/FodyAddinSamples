using System.ComponentModel;
using NUnit.Framework;

[TestFixture]
public class Sample
{
    [Test]
    public void Run()
    {
        var target = new Target();
        var property1Changing = false;
        target.PropertyChanging+=(sender, args) => property1Changing = true;
        target.Propert1 = "New Value";
        Assert.IsTrue(property1Changing);
    }
}

public class Target: INotifyPropertyChanging
{
    public string Propert1 { get; set; }
    public event PropertyChangingEventHandler PropertyChanging;
}