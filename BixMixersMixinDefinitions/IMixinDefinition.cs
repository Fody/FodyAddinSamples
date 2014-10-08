using System;
using System.Collections.Generic;

namespace BixMixersMixinDefinitions
{
    public interface IMixinDefinition
    {
        int Property { get; }
        List<string> Method(int arg0, params string[] args);
        event EventHandler<UnhandledExceptionEventArgs> AFunnyThingHappened;
        string GenericMethod<T>(T input);
    }
}
