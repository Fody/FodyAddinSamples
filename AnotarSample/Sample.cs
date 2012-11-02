using System;
using System.Collections.Generic;
using System.Linq;
using Anotar;
using NLog;
using NLog.Config;
using NLog.Targets;
using NUnit.Framework;

[TestFixture]
public class Sample
{
    [Test]
    public void Run()
    {
        var getLog = SetupNLog();
        MyMethod();

        Assert.AreEqual("Method: MyMethod. Line: ~24. TheMessage", getLog());
    }

    static void MyMethod()
    {
        Log.Debug("TheMessage");
    }

    Func<string> SetupNLog()
    {
        var target = new MemoryTarget
                         {
                             Layout = "${message}"
                         };
        var config = new LoggingConfiguration();
        config.AddTarget("trace", target);

        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));

        LogManager.Configuration = config;

        return ()=> target.Logs.First();
    }

}