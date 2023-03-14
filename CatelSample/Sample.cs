using Catel.Data;
using Xunit;

public class Sample
{
    [Fact]
    public void Run()
    {
        var target = new Target();
        var property1Changed = false;
        target.PropertyChanged += (_, _) => property1Changed = true;
        target.Property1 = "New Value";
        Assert.True(property1Changed);
    }
}

public class Target: ModelBase
{
    public string Property1 { get; set; }
}