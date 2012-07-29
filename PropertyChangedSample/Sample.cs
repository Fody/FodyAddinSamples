using System.ComponentModel;
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
        target.Propert1 = "New Value";
        Assert.IsTrue(property1Changed);
    }
}

public class Target: INotifyPropertyChanged
{
    public string Propert1 { get; set; }
    public event PropertyChangedEventHandler PropertyChanged;
}