using System.Diagnostics;
using System.IO;
using NUnit.Framework;

public static class ModuleInitializer
{
    public static void Initialize()
    {
        //Delete the ref assembly in a ModuleInitializer since it will not be loaded and locked at this time
        var path = Path.Combine(AssemblyLocation.CurrentDirectory(), "CosturaAssemblyToReference.dll");
        File.Delete(path);
    }
}

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