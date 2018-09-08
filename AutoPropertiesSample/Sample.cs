using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AutoProperties;
using Xunit;
// ReSharper disable UnusedParameter.Local

public class AutoPropertiesSetBackingField : INotifyPropertyChanged
{
    int numberOfPropertyChangedCalls;

    public string AutoProperty1 { get; set; }
    public string AutoProperty2 { get; set; }

    public AutoPropertiesSetBackingField()
    {
        AutoProperty2.SetBackingField("42");
    }

    [Fact]
    public void Run()
    {
        // no property changed call was generated in constructor:
        Assert.Equal(0, numberOfPropertyChangedCalls);
        Assert.Equal("42", AutoProperty2);

        AutoProperty1 = "Test1";
        Assert.Equal(1, numberOfPropertyChangedCalls);
        Assert.Equal("Test1", AutoProperty1);

        AutoProperty1.SetBackingField("Test2");
        Assert.Equal(1, numberOfPropertyChangedCalls);
        Assert.Equal("Test2", AutoProperty1);
    }


    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        numberOfPropertyChangedCalls += 1;

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class AutoPropertiesInterceptor
{
    [Fact]
    public void Run()
    {
        Assert.Equal(8, Property1);
        Assert.Equal("9", Property2);

        Property1 = 42;

        Assert.Equal(45, Property1);
        Assert.Equal("9", Property2);

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

