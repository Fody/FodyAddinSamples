﻿using Anotar.NServiceBus;
using Xunit;

namespace AnotarNServiceBusSample
{
    public class NServiceBusExplicitSample
    {
        [Fact]
        public void Run()
        {
            MyMethod();

            Assert.Equal("Method: 'Void MyMethod()'. Line: ~16. TheMessage", LogCaptureBuilder.LastMessage);
        }

        static void MyMethod()
        {
            LogTo.Debug("TheMessage");
        }
    }
}