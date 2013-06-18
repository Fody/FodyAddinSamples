using System.Diagnostics;
using NUnit.Framework;

[TestFixture]
public class ToStringSample
{
    [Test]
    public void Run()
    {
        var target = new Person
                     {
                         GivenNames = "John",
                         FamilyName = "Smith"

                     };
        Debug.WriteLine(target.ToString());
        Assert.AreEqual("{T: Person, GivenNames: \"John\", FamilyName: \"Smith\"}",target.ToString());
    }
}

[ToString]
class Person
{
    public string GivenNames { get; set; }
    public string FamilyName { get; set; }

    [IgnoreDuringToString]
    public string FullName
    {
        get
        {
            return string.Format("{0} {1}", GivenNames, FamilyName);
        }
    }
}