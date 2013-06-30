using System.IO;

public static class ModuleInitializer
{
    public static void Initialize()
    {
        //Delete the ref assembly in a ModuleInitializer since it will not be loaded and locked at this time
        var path = Path.Combine(AssemblyLocation.CurrentDirectory(), "CosturaAssemblyToReference.dll");
        File.Delete(path);
    }
}