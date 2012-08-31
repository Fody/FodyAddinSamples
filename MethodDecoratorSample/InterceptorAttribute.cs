using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor)]
public class InterceptorAttribute : Attribute, IMethodDecorator
{
    public void OnEntry(MethodBase method)
    {
        InterceptionRecorder.OnEntryCalled = true;
    }

    public void OnExit(MethodBase method)
    {
        InterceptionRecorder.OnExitCalled = true;
    }

    public void OnException(MethodBase method, Exception exception)
    {
        InterceptionRecorder.OnExceptionCalled = true;
    }
}