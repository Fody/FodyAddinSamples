
using System.Reflection.Emit;
using InlineIL;

namespace InlineILSample
{
    public static class ZeroInit
    {
        public static void InitStruct<T>(ref T value)
            where T : struct
        {
            IL.Push(ref value);

            IL.Emit(OpCodes.Ldc_I4_0);

            IL.Emit(OpCodes.Sizeof, typeof(T));

            IL.Emit(OpCodes.Unaligned, 1);
            IL.Emit(OpCodes.Initblk);
        }
    }
}
