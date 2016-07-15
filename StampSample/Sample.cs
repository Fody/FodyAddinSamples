using System.Diagnostics;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class StampSample
{
    [Test]
    public void Run()
    {
		var infoAttribute = (AssemblyInformationalVersionAttribute)GetType().Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false).First();
		Assert.IsNotNull(infoAttribute.InformationalVersion);
		Assert.IsNotEmpty(infoAttribute.InformationalVersion);
        Debug.WriteLine(infoAttribute.InformationalVersion);
    }
}
