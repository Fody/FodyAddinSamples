using System;
using Anotar.Log4Net;
using Xunit;

namespace AnotarLog4NetSample
{
    public class Log4NetExceptionSample
    {
        [Fact]
        public void Run()
        {
            try
            {
                MyMethod();
            }
            catch
            {
            }

            Assert.Equal("Exception occurred in 'Void MyMethod()'. ", LogCaptureBuilder.LastMessage);
        }

        [LogToDebugOnException]
        static void MyMethod()
        {
            throw new Exception("Foo");
        }
    }
}