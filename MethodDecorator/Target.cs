using System;

public static class Target
{
    [Interceptor]
    public static void MyMethod()
    {

    }

    [Interceptor]
    public static void MyExceptionMethod()
    {
        throw new Exception("Foo");
    }
}