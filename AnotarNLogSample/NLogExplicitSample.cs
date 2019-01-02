using Anotar.NLog;
using Xunit;

namespace AnotarNLogSample
{
    public class NLogExplicitSample
    {
        [Fact]
        public void Run()
        {
            MyMethod();

            Assert.Equal("Method: 'Void MyMethod()'. Line: ~18. TheMessage", LogCaptureBuilder.LastMessage);
        }

        static void MyMethod()
        {
            LogTo.Debug("TheMessage");
        }

    }
}