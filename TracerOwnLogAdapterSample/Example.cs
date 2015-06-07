using System.Diagnostics;
using NUnit.Framework;
using TracerAttributes;
using TracerOwnLogAdapter.Adapters;

namespace TracerOwnLogAdapterSample
{
    [TestFixture]
    [NoTrace]
    public class Example
    {
        [Test]
        public void Test()
        {
            new ClassToLog().Run();

            LoggerAdapter.LoggedLines.ForEach(line => Debug.Print(line));
            Assert.AreEqual(5, LoggerAdapter.LoggedLines.Count);
        }
    }
}
