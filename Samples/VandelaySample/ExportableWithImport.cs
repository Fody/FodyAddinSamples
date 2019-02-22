using System.ComponentModel.Composition;

namespace VandelaySample
{
    public class ExportableWithImport : IExportable
    {
        [Import]
        public Foo MyFoo { get; set; }
    }
}