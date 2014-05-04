using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BixMixersMixinDefinitions
{
    public interface IMixinDefinition
    {
        int Property { get; }
        List<string> Method(int arg0, params string[] args);
        event EventHandler<UnhandledExceptionEventArgs> AFunnyThingHappened;
    }
}
