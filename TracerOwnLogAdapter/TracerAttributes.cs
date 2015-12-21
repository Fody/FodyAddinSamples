using System;

// ReSharper disable once CheckNamespace
namespace TracerAttributes
{
    //This one is required for the attributes to avoid referencing anything from tracer in the production code
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class TraceOn : Attribute
    {
        public TraceTarget Target { get; set; }

        public TraceOn()
        { }

        public TraceOn(TraceTarget traceTarget)
        {
            Target = traceTarget;
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class NoTrace : Attribute
    {
    }

    public enum TraceTarget
    {
        Public,
        Internal,
        Protected,
        Private
    }

}
