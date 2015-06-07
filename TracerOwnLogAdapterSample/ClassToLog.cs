using TracerAttributes;
using TracerOwnLogAdapter;

namespace TracerOwnLogAdapterSample
{
    [TraceOn(TraceTarget.Protected)]
    public class ClassToLog
    {
        public void Run()
        {
            MyLog.SomethingImportant(42, "LogInfoLine");
            var result = 0;
            WillBeTracedAsProtected(ref result, 100);
        }

        protected int WillBeTracedAsProtected(ref int result, int input)
        {
            WontBeTracedAsPrivate();
            result = 100 / input;
            return 42;
        }

        void WontBeTracedAsPrivate()
        {

        }
    }
}