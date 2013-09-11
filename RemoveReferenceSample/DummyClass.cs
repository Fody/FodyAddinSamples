using System.Xml.Linq;

namespace RemoveReferenceSample
{
    /// <summary>
    /// Dummy class
    /// </summary>
    public class DummyClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyClass"/> class.
        /// </summary>
        public DummyClass()
        {
            XDocument xmlDoc = XDocument.Load(@"dummy.xml");
        }
    }
}
