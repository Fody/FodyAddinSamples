using System.Collections.Generic;
using System.ComponentModel;
using Xunit;

public class PropertyChangingSample
{
    [Fact]
    public void Run()
    {
        var target = new Person();
        var propertyNotifications = new List<string>();
        target.PropertyChanging += (sender, args) => propertyNotifications.Add(args.PropertyName);
        target.FamilyName = "Smith";
        Assert.Contains("FamilyName", propertyNotifications);
        Assert.Contains("FullName", propertyNotifications);
    }
}

public class Person : INotifyPropertyChanging
{
    public event PropertyChangingEventHandler PropertyChanging;

    public string GivenNames { get; set; }
    public string FamilyName { get; set; }

    public string FullName => $"{GivenNames} {FamilyName}";
}