using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NUnit.Framework;

namespace CommanderSample
{
    [TestFixture]
    public class CommanderSample
    {
        [Test]
        public void Run()
        {
            Assert.IsNotNull(typeof(SampleViewModel).GetProperty("TickCommand"));
        }

        [Test]
        public void RunExecute()
        {
            var sample = new SampleViewModel();
            var property = sample.GetType().GetProperty("TickCommand");
            var command = (ICommand) property.GetValue(sample);
            command.Execute(null); 
            command.Execute(null);
            Assert.That(sample.Ticks, Is.EqualTo(2));
        }
    }
}
