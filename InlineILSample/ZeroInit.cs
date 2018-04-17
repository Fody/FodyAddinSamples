using static InlineIL.IL.Emit;

namespace InlineILSample
{
    public static class ZeroInit
    {
        public static void InitStruct<T>(ref T value)
            where T : struct
        {
            Ldarg(nameof(value));

            Ldc_I4_0();

            Sizeof(typeof(T));

            Unaligned(1);
            Initblk();
        }
    }
}