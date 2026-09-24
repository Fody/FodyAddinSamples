using Catel.Data;

public class Sample
{
    [Test]
    public async Task Run()
    {
        var target = new Target();
        var property1Changed = false;
        target.PropertyChanged += (_, _) => property1Changed = true;
        target.Property1 = "New Value";
        await Assert.That(property1Changed).IsTrue();
    }
}

public class Target: ModelBase
{
    public string Property1 { get; set; }
}