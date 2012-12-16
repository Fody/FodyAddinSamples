#if (!MONO)
using NUnit.Framework;

[TestFixture]
public class Sample
{
    [Test]
    public async void Run()
    {
        var instance = new Target();
        await instance.MethodWithThrow();
        //run and have a look at the debug window
    }
}
#endif