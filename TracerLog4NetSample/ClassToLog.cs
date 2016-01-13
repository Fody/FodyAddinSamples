using Tracer.Log4Net;
using TracerAttributes;
// ReSharper disable RedundantAssignment

namespace TracerLog4NetSample
{
    [TraceOn(TraceTarget.Protected)]
    public class ClassToLog
    {
        public void Run()
        {
            Log.Info("LogInfoLine");
            var result = 0;
            WillBeTracedAsProtected(ref result, 100);
        }

        protected int WillBeTracedAsProtected(ref int result, int input)
        {
            WontBeTracedAsPrivate();
            result = 100/input;
            return 42;
        }

        void WontBeTracedAsPrivate()
        {
            
        }
    }
}