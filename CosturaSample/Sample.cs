using System.Diagnostics;
using System.IO;

public class CosturaTests
{
    public CosturaTests()
    {
        var path = Path.Combine(AssemblyLocation.CurrentDirectory(), "CosturaAssemblyToReference.dll");
        File.Delete(path);
    }

    [Test]
    public void Run() =>
        //Note that this will work even though CosturaAssemblyToReference.dll does not exists in the execution directory
        Debug.WriteLine(ClassInReferenceAssembly.SayHello());
}