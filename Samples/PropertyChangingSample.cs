using System.Collections.Generic;
using System.ComponentModel;

public class PropertyChangingSample
{
    [Test]
    public async Task Run()
    {
        var target = new Person();
        var propertyNotifications = new List<string>();
        target.PropertyChanging += (_, args) => propertyNotifications.Add(args.PropertyName);
        target.FamilyName = "Smith";
        await Assert.That(propertyNotifications).Contains("FamilyName");
        await Assert.That(propertyNotifications).Contains("FullName");
    }

    public class Person : INotifyPropertyChanging
    {
        public event PropertyChangingEventHandler PropertyChanging;

        public string GivenNames { get; set; }
        public string FamilyName { get; set; }

        public string FullName => $"{GivenNames} {FamilyName}";
    }
}