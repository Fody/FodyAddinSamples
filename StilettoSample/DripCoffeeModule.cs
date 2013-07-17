using Stiletto;

namespace StilettoSample
{
    [Module(
        Injects = new[] { typeof(Sample) },
        IncludedModules = new[] { typeof(PumpModule) })]
    public class DripCoffeeModule
    {
        [Provides, Singleton]
        public IHeater GetHeater()
        {
            return new ElectricHeater();
        }
    }
}
