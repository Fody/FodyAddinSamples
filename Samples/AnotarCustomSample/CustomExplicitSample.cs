using Anotar.Custom;
using Xunit;

namespace AnotarCustomSample
{
    public class CustomExplicitSample
    {
        [Fact]
        public void Run()
        {
            MyMethod();

            Assert.Equal("Method: 'Void MyMethod()'. Line: ~18. TheMessage", Logger.LastMessage.Format);
        }

        static void MyMethod()
        {
            LogTo.Debug("TheMessage");
        }
    }
}