using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Resources;

using Substitute;

[assembly: Substitute(typeof(ComponentResourceManager), typeof(MyComponentResourceManager))]
[assembly: Substitute(typeof(ResourceManager), typeof(MyResourceManager))]

public class MyComponentResourceManager : ComponentResourceManager
{
    public MyComponentResourceManager(Type t)
        : base(t)
    {
    }

    // a substitute must implement all (even implicit) used methods of the substituted type.
    public new void ApplyResources(object value, string objectName)
    {
        base.ApplyResources(value, objectName);
    }

    public override void ApplyResources(object value, string objectName, CultureInfo culture)
    {
        ((dynamic)value).Text = GetString($"{objectName}.Text", culture);
    }

    public override string GetString(string name, CultureInfo culture)
    {
        return $"Override: {name} => {base.GetString(name, culture)}";
    }
}

public class MyResourceManager : ResourceManager
{
    public MyResourceManager(string s, Assembly assembly)
        : base(s, assembly)
    {

    }

    public override string GetString(string name, CultureInfo culture)
    {
        return $"Override: {name} => {base.GetString(name, culture)}";
    }
}