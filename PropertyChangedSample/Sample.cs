using System.Collections.Generic;
using System.ComponentModel;
using NUnit.Framework;

[TestFixture]
public class Sample
{
    [Test]
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

public class Person : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public string GivenNames { get; set; }
    public string FamilyName { get; set; }

    public string FullName
    {
        get
        {
            return string.Format("{0} {1}", GivenNames, FamilyName);
        }
    }
}