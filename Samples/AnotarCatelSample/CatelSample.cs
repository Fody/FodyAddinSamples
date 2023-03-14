using System;
using Anotar.Catel;
using Catel.Logging;
using Xunit;

namespace AnotarCatelSample;

public class CatelSample
{
    [ThreadStatic]
    public static string LastMessage;

    static CatelSample()
    {
        LogManager.AddListener(new LogListener
        {
            Action = (s, _) => { LastMessage = s; }
        });
    }

    [Fact]
    public void RunException()
    {
        try
        {
            MyExceptionMethod();
        }
        catch
        {
        }

        Assert.StartsWith("Exception occurred in 'Void MyExceptionMethod()'", LastMessage);
    }

    [LogToDebugOnException]
    static void MyExceptionMethod()
    {
        throw new("Foo");
    }

    [Fact]
    public void RunExplicit()
    {
        MyMethod();

        Assert.Equal("Method: 'Void MyMethod()'. Line: ~51. TheMessage", LastMessage);
    }

    static void MyMethod()
    {
        LogTo.Debug("TheMessage");
    }
}