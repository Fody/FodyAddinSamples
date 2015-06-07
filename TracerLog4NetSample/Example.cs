using log4net;
using log4net.Config;
using log4net.Core;
using log4net.Repository.Hierarchy;
using NUnit.Framework;
using TracerAttributes;

namespace TracerLog4NetSample
{
    [TestFixture]
    [NoTrace]
    public class Example
    {
        [Test]
        public void Test()
        {
            //setup logging
            var appender = new InMemoryAppender();
            BasicConfigurator.Configure(appender);
            ((Hierarchy) LogManager.GetRepository()).Root.Level = Level.All;

            new ClassToLog().Run();

            appender.PrintToDebug();
            Assert.AreEqual(5, appender.EventCount);
        }
    }
}
