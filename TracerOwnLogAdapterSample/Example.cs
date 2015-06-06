using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TracerAttributes;
using TracerOwnLogAdapter;
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

    [TraceOn(TraceTarget.Protected)]
    public class ClassToLog
    {
        public void Run()
        {
            MyLog.SomethingImportant(42, "LogInfoLine");
            int result = 0;
            WillBeTracedAsProtected(ref result, 100);
        }

        protected int WillBeTracedAsProtected(ref int result, int input)
        {
            WontBeTracedAsPrivate();
            result = 100 / input;
            return 42;
        }

        private void WontBeTracedAsPrivate()
        {

        }
    }
}
