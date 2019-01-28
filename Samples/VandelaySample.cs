using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Vandelay;
using VandelaySample;
using Xunit;

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
