using System;
using System.Globalization;
using System.IO;
using JetBrains.Annotations;
using Xunit;

public class JetBrainsAnnotationsSample
{
    [Fact]
    public void Run()
    {
        var outputFolder = Path.GetDirectoryName(new Uri(GetType().Assembly.CodeBase).LocalPath);
        var projectFolder = Path.GetFullPath(Path.Combine(outputFolder, "..", "..", ".."));

        var expected = File.ReadAllText(Path.Combine(projectFolder, "JetBrainsAnnotationsSample.ExternalAnnotations.Expected.xml"));
        var generatedFileName = Path.Combine(projectFolder, "JetBrainsAnnotationsSample.ExternalAnnotations.xml");

        Assert.True(File.Exists(generatedFileName));

        var generated = File.ReadAllText(generatedFileName);

        Assert.Equal(expected, generated);
    }

    [CanBeNull]
    public object AnyMethod([NotNull, UsedImplicitly] object anyParam)
    {
        return null;
    }

    [NotNull]
    public object AnyProperty { get; set; }

    [NotNull, StringFormatMethod("format")]
    public string Format([NotNull] string format, [NotNull, ItemNotNull] params object[] args)
    {
        return string.Format(CultureInfo.CurrentCulture, format, args);
    }
}