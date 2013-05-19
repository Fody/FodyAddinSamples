using System.Linq;
using NUnit.Framework;
using JetBrains.Annotations;

[TestFixture]
public class JetBrainsAnnotationsSample
{
    [Test]
    public void Run()
    {
        var referencedAssemblies = GetType().Assembly.GetReferencedAssemblies();
        Assert.IsFalse(referencedAssemblies.Any(x => x.Name == "JetBrains.Annotations"));
    }

    public void MethodWithParam([NotNull]string param)
    {
        
    }
    public void MethodCalling()
    {
        //There will be a warning here if you have resharper installed
        MethodWithParam(null);
    }
}