using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace RemoveReferenceSample
{
    /// <summary>
    /// Sample tests
    /// </summary>
    [TestFixture]
    public class Sample
    {
        /// <summary>
        /// Test method that asserts the "System.Xml.Linq" assembly is not referenced.
        /// </summary>
        [Test]
        public void Run()
        {
            var assembly = Assembly.GetExecutingAssembly();

            Assert.IsTrue(assembly.GetReferencedAssemblies().All(x => x.Name != "System.Xml.Linq"));
        }
    }
}
