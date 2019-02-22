using System.Collections.Generic;

namespace VandelaySample
{
    public static class Importer
    {
        public static IEnumerable<IExportable> WithoutExport { get; } =
            Vandelay.Importer.ImportMany<IExportable>("Samples.dll");

        public static IEnumerable<IExportable> WithExport { get; } =
            Vandelay.Importer.ImportMany<IExportable>("Samples.dll", new Foo());
    }
}