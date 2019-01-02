using Anotar.Serilog;
using Xunit;

namespace AnotarSerilogSample
{
    public class SerilogExplicitSample
    {
        [Fact]
        public void Run()
        {
            MyMethod();

            var lastMessage = LogCaptureBuilder.LastMessage;
            Assert.Equal("Void MyMethod()", lastMessage.MethodName());
            Assert.Equal(21, lastMessage.LineNumber());
            Assert.Equal("TheMessage", lastMessage.MessageTemplate.Text);
        }

        static void MyMethod()
        {
            LogTo.Debug("TheMessage");
        }

    }
}