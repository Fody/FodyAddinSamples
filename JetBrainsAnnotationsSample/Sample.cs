using System;
using System.Globalization;
using System.IO;
using JetBrains.Annotations;
using Xunit;

/// <summary>
/// The sample class.
/// </summary>
public class JetBrainsAnnotationsSample
{
    /// <summary>
    /// Runs the tests.
    /// </summary>
    [Fact]
    public void Run()
    {
        var outputFolder = Path.GetDirectoryName(new Uri(GetType().Assembly.CodeBase).LocalPath);
        var projectFolder = Path.GetFullPath(Path.Combine(outputFolder, "..", "..", ".."));

        // 1. Annotations for the attributes are generated
        var expectedAnnotations = File.ReadAllText(Path.Combine(projectFolder, "JetBrainsAnnotationsSample.ExternalAnnotations.Expected.xml"));
        var generatedAnnotationsFileName = Path.Combine(projectFolder, "JetBrainsAnnotationsSample.ExternalAnnotations.xml");

        Assert.True(File.Exists(generatedAnnotationsFileName));

        var generatedAnnotations = File.ReadAllText(generatedAnnotationsFileName);

        Assert.Equal(expectedAnnotations, generatedAnnotations);

        // 2. XML Documentation is decorated with attributes
        var expectedDocumentation = File.ReadAllText(Path.Combine(projectFolder, "JetBrainsAnnotationsSample.Expected.xml"));
        var generatedDocumentationFileName = Path.Combine(outputFolder, "JetBrainsAnnotationsSample.xml");

        Assert.True(File.Exists(generatedDocumentationFileName));

        var generatedDocumentation = File.ReadAllText(generatedDocumentationFileName);

        Assert.Equal(expectedDocumentation, generatedDocumentation);
    }

    /// <summary>
    /// This is an annotated method.
    /// </summary>
    /// <param name="anyParam">Any parameter.</param>
    /// <returns>something</returns>
    [CanBeNull]
    public object AnyMethod([NotNull, UsedImplicitly] object anyParam)
    {
        return null;
    }

    /// <summary>
    /// Gets or sets the annotated property.
    /// </summary>
    [NotNull]
    public object AnyProperty { get; set; }

    /// <summary>
    /// String format annotated.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    /// <returns>The result.</returns>
    [NotNull, StringFormatMethod("format")]
    public string Format([NotNull] string format, [NotNull, ItemNotNull] params object[] args)
    {
        return string.Format(CultureInfo.CurrentCulture, format, args);
    }
}