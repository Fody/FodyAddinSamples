using System;
using System.Reflection;
using MethodDecorator.Fody.Interfaces;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Module)]
public class InterceptorAttribute : Attribute, IMethodDecorator
{
    public void Init(object instance, MethodBase method, object[] args)
    {
    }

    public void OnEntry()
    {
        InterceptionRecorder.OnEntryCalled = true;
    }

    public void OnExit()
    {
        InterceptionRecorder.OnExitCalled = true;
    }

    public void OnException(Exception exception)
    {
        InterceptionRecorder.OnExceptionCalled = true;
    }
}
