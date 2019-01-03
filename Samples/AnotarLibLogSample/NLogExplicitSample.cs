using Anotar.LibLog;
using Xunit;

namespace AnotarLibLogSample
{
    public class LibLogExplicitSample
    {
        [Fact]
        public void Run()
        {
            MyMethod();

            Assert.Equal("Method: 'Void MyMethod()'. Line: ~18. TheMessage", CustomProvider.LastMessage);
        }

        static void MyMethod()
        {
            LogTo.Debug("TheMessage");
        }
    }
}