using System.Collections.Generic;
using System.ComponentModel;
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
        Assert.Contains("FamilyName", propertyNotifications);
        Assert.Contains("FullName", propertyNotifications);
    }

    public class Person :
        INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string GivenNames { get; set; }
        public string FamilyName { get; set; }

        public string FullName => $"{GivenNames} {FamilyName}";
    }
}