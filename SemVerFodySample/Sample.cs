using System.Diagnostics;
using NUnit.Framework;

// ReSharper disable ExceptionNotDocumentedOptional
// ReSharper disable NonLocalizedString
// ReSharper disable CheckNamespace

[TestFixture]
public class Sample
{
    [Test]
    public void Run()
    {
        var assembly = GetType().Assembly;
        var fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
        var fileVersion = fileVersionInfo.FileVersion;

        Assert.IsNotEmpty(fileVersion);
        Assert.IsNotNull(fileVersion);
        Assert.AreEqual(fileVersion, "0.1.0.0");
        Debug.WriteLine(fileVersion);
    }
}