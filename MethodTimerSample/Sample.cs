using System.Threading;
using MethodTimer;
using NUnit.Framework;

[TestFixture]
public class Sample
{
    [Test]
    [Time]
    public void MyMethod()
    {
        //Run and have a look in your debug window
        Thread.Sleep(1500);
    }

}