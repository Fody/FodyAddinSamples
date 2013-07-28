using Catel.Data;
using NUnit.Framework;

[TestFixture]
public class Sample
{
    [Test]
    public void Run()
    {
        var target = new Target();
        var property1Changed = false;
        target.PropertyChanged+=(sender, args) => property1Changed = true;
        target.Property1 = "New Value";
        Assert.IsTrue(property1Changed);
    }
}

public class Target: ModelBase
{
    public string Property1 { get; set; }
}