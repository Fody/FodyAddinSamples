using System.Collections.Generic;
using Xunit;

public class PropertyChangedSample
{
    [Fact]
    public void Run()
    {
        var target = new Person();
        var propertyNotifications = new List<string>();
        target.PropertyChanged += (sender, args) => propertyNotifications.Add(args.PropertyName);
        target.FamilyName = "Smith";
        Assert.Contains("FamilyName",propertyNotifications);
        Assert.Contains("FullName", propertyNotifications);
    }
}