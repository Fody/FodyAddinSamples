using System.Diagnostics;
using System.IO;
using Xunit;

public class CosturaSample
{
    public CosturaSample()
    {
        var path = Path.Combine(AssemblyLocation.CurrentDirectory(), "CosturaAssemblyToReference.dll");
        File.Delete(path);
    }

    [Fact]
    public void Run()
    {
        //Note that this will work even though CosturaAssemblyToReference.dll does not exists in the execution directory
        Debug.WriteLine(ClassInReferenceAssembly.SayHello());
    }
}