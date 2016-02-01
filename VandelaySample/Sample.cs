using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using NUnit.Framework;
using Vandelay;
using VandelaySample;

[assembly: Exporter(typeof(IExportable))]

namespace VandelaySample
{
  public interface IExportable
  {
  }

  public class Exportable : IExportable
  {
  }

  public class Foo
  {
  }

  public class ExportableWithImport : IExportable
  {
    [Import]
    public Foo MyFoo { get; set; }
  }

  public static class Importer
  {
    public static IEnumerable<IExportable> WithoutExport { get; } =
      Vandelay.Importer.ImportMany<IExportable>("");

    public static IEnumerable<IExportable> WithExport { get; } =
      Vandelay.Importer.ImportMany<IExportable>("", new Foo());
  }

  [TestFixture]
  public class Sample
  {
    [Test]
    public void WithoutExport()
    {
      var imports = Importer.WithoutExport;

      Assert.That(imports, Is.Not.Null.Or.Empty);
      Assert.That(imports, Has.Length.EqualTo(1));
    }

    [Test]
    public void WithExport()
    {
      var imports = Importer.WithExport;

      Assert.That(imports, Is.Not.Null.Or.Empty);
      Assert.That(imports, Has.Length.EqualTo(2));

      var withImport = imports.OfType<ExportableWithImport>().Single();
      Assert.That(withImport.MyFoo, Is.Not.Null);
    }
  }
}
