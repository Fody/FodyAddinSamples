using System;
using NUnit.Framework;

[TestFixture]
public class Sample
{
    [Test]
    public void Run()
    {
        var person = new Person();

        // Set a value before freeze
        person.Name = "John Smith";

        // Now freeze
        person.Freeze();

        // Now try to set the property again and it will throw a InvalidOperationException
        Assert.Throws<InvalidOperationException>(() => person.Name = "John Doe");
    }

}