using System;
using System.Diagnostics;
using ArxOne.Weavisor.Advice;
using NUnit.Framework;

public class WeavisorSample
{
    public static bool beforeReceived;
    public static bool afterReceived;

    [Test]
    public void Run()
    {
        MyMethodWithAdvice();
        Assert.IsTrue(beforeReceived);
        Assert.IsTrue(afterReceived);
    }

    [MyAdvice]
    public void MyMethodWithAdvice()
    {
        Trace.WriteLine("Hello");
    }
}

public class MyAdvice : Attribute, IMethodAdvice
{

    public void Advise(MethodAdviceContext context)
    {
        // do things you want here
        Trace.WriteLine("Before");
        WeavisorSample.beforeReceived = true;

        // this calls the original method
        context.Proceed();

        // do other things here
        Trace.WriteLine("Before");
        WeavisorSample.afterReceived = true;
    }
}
