using Bix.Mixers.Fody.InterfaceMixins;
using BixMixersMixinDefinitions;

namespace BixMixersMixinTargets
{
    [InterfaceMixin(typeof(IMixinDefinition))]
    public class MixinTarget
    {
        static MixinTarget()
        {
            NonMixinStaticValue = 34;
        }

        public MixinTarget() : this(532) { ++InstanceConstructorCalledCount; }

        public MixinTarget(int value)
        {
            ++InstanceConstructorCalledCount;
            this.NonMixinValue = value;
        }

        public int NonMixinProperty { get { return 5; } }

        public static int NonMixinStaticValue;
        public int NonMixinValue;

        public static int InstanceConstructorCalledCount;
    }
}
