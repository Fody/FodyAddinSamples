using Mixins;
using NUnit.Framework;

public interface IAddedFunc
{
    string Func();
}

public class AddedFunc : IAddedFunc
{
    public string Func()
    {
        return "String from Mixin";
    }
}

[Mixin(typeof(AddedFunc))]
public class Target 
{
}


[TestFixture]
public class Sample
{
    [Test]
    public void Run()
    {
        var target = (IAddedFunc)new Target();
        Assert.AreEqual("String from Mixin",target.Func());
    }
}