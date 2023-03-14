using System.ComponentModel;
using System.Runtime.CompilerServices;
using AutoProperties;
using Xunit;
// ReSharper disable UnusedParameter.Local

public class AutoPropertiesSample : INotifyPropertyChanged
{
    int numberOfPropertyChangedCalls;

    public string AutoProperty1 { get; set; }
    public string AutoProperty2 { get; set; }

    public AutoPropertiesSample()
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

        PropertyChanged?.Invoke(this, new(propertyName));
    }
}