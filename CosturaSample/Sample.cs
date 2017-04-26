using System.Diagnostics;
using System.IO;
using NUnit.Framework;

[TestFixture]
public class CosturaSample
{

    [OneTimeSetUp]
    public void Setup()
    {
        var path = Path.Combine(AssemblyLocation.CurrentDirectory(), "CosturaAssemblyToReference.dll");
        File.Delete(path);
    }

    [Test]
    public void Run()
    {
        //Note that this will work even though CosturaAssemblyToReference.dll does not exists in the execution directory
        Debug.WriteLine(ClassInReferenceAssembly.SayHello());
    }
}