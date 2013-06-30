using System.Diagnostics;
using NUnit.Framework;

[TestFixture]
public class CosturaSample
{
    [Test]
    public void Run()
    {
        //Note that this will work even though CosturaAssemblyToReference.dll does not exists in the execution directory
        Debug.WriteLine(ClassInReferenceAssembly.SayHello());
    }
}