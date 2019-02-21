using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Xunit;

[assembly: Vandelay.Exporter(typeof(VandelaySample.IExportable))]

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
            Vandelay.Importer.ImportMany<IExportable>("Samples.dll");

        public static IEnumerable<IExportable> WithExport { get; } =
            Vandelay.Importer.ImportMany<IExportable>("Samples.dll", new Foo());
    }

    public class Sample
    {
        [Fact]
        public void WithoutExport()
        {
            var imports = Importer.WithoutExport.ToList();

            Assert.NotNull(imports);
            Assert.NotEmpty(imports);
            Assert.Single(imports);
        }

        [Fact]
        public void WithExport()
        {
            var imports = Importer.WithExport.ToList();

            Assert.NotNull(imports);
            Assert.NotEmpty(imports);
            Assert.Equal(2, imports.Count);

            var withImport = imports.OfType<ExportableWithImport>().Single();
            Assert.NotNull(withImport.MyFoo);
        }
    }
}
