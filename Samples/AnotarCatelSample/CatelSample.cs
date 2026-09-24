using System;
using Anotar.Catel;
using Catel.Logging;

namespace AnotarCatelSample;

// the tests in this namespace share the static last logged message
[NotInParallel]
public class CatelSample
{
    [ThreadStatic]
    public static string LastMessage;

    static CatelSample() =>
        LogManager.AddListener(new LogListener
        {
            Action = (s, _) => { LastMessage = s; }
        });

    [Test]
    public async Task RunException()
    {
        try
        {
            MyExceptionMethod();
        }
        catch
        {
        }

        await Assert.That(LastMessage).StartsWith("Exception occurred in 'Void MyExceptionMethod()'");
    }

    [LogToDebugOnException]
    static void MyExceptionMethod() =>
        throw new("Foo");

    [Test]
    public async Task RunExplicit()
    {
        MyMethod();

        await Assert.That(LastMessage).IsEqualTo("Method: 'Void MyMethod()'. Line: ~47. TheMessage");
    }

    static void MyMethod() =>
        LogTo.Debug("TheMessage");
}