
using System;
using System.Globalization;
using System.Linq;

public class ConsoleLogInterceptor : IDynamicInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        var arguments = string.Join(", ", invocation.Arguments.Select(FormatArgumentValue));

        Console.WriteLine("Intercepting {0}({1})", invocation.Method.Name, arguments);

        invocation.Proceed();

        if (invocation.Method.ReturnType == typeof(void))
        {
            Console.WriteLine("Method {0} returned", invocation.Method.Name);
        }
        else
        {
            var returnValue = FormatArgumentValue(invocation.ReturnValue);
            Console.WriteLine("Method {0} returned {1}", invocation.Method.Name, returnValue);
        }
    }

    static string FormatArgumentValue(object value)
    {
        if (value == null)
        {
            return "null";
        }

        return string.Format(CultureInfo.InvariantCulture, "{0}", value);
    }
}