using System;
using AutoProperties;
using Xunit;
// ReSharper disable UnusedParameter.Local

public class AutoPropertiesInterceptor
{
    [Fact]
    public void Run()
    {
        Assert.Equal(10, Property1);
        Assert.Equal("11", Property2);

        Property1 = 42;

        Assert.Equal(45, Property1);
        Assert.Equal("11", Property2);

        Property2 = "44";

        Assert.Equal(45, Property1);
        Assert.Equal("47", Property2);
    }

    [GetInterceptor]
    T GetInterceptor<T>(string propertyName, T fieldValue)
    {
        return (T)Convert.ChangeType(Convert.ToInt32(fieldValue) + 1, typeof(T));
    }

    [SetInterceptor]
    void SetInterceptor<T>(T value, string propertyName, out T field)
    {
        field = (T)Convert.ChangeType(Convert.ToInt32(value) + 2, typeof(T));
    }

    public int Property1 { get; set; } = 7;

    public string Property2 { get; set; } = "8";
}