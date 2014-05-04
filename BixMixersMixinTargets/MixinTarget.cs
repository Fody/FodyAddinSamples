using Bix.Mixers.Fody.InterfaceMixins;
using BixMixersMixinDefinitions;

namespace BixMixersMixinTargets
{
    [InterfaceMixin(typeof(IMixinDefinition))]
    public class MixinTarget
    {
        public int NonMixinProperty { get { return 5; } }
    }
}
