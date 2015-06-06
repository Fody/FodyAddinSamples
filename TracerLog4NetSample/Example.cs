using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Repository.Hierarchy;
using NUnit.Framework;
using Tracer.Log4Net;
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
            ((Hierarchy) log4net.LogManager.GetRepository()).Root.Level = Level.All;

            new ClassToLog().Run();

            appender.PrintToDebug();
            Assert.AreEqual(5, appender.EventCount);
        }
    }

    [TraceOn(TraceTarget.Protected)]
    public class ClassToLog
    {
        public void Run()
        {
            Log.Info("LogInfoLine");
            int result = 0;
            WillBeTracedAsProtected(ref result, 100);
        }

        protected int WillBeTracedAsProtected(ref int result, int input)
        {
            WontBeTracedAsPrivate();
            result = 100/input;
            return 42;
        }

        private void WontBeTracedAsPrivate()
        {
            
        }
    }
}
