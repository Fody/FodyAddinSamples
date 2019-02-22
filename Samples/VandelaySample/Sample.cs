using System.Linq;
using Xunit;

namespace VandelaySample
{
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