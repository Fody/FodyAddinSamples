using System.Diagnostics;

public class ToStringTests
{
    [Test]
    public async Task Run()
    {
        var target = new Person
                     {
                         GivenNames = "John",
                         FamilyName = "Smith"

                     };
        Debug.WriteLine(target.ToString());
        await Assert.That(target.ToString()).IsEqualTo("{T: \"Person\", GivenNames: \"John\", FamilyName: \"Smith\"}");
    }
}

[ToString]
class Person
{
    public string GivenNames { get; set; }
    public string FamilyName { get; set; }

    [IgnoreDuringToString]
    public string FullName => $"{GivenNames} {FamilyName}";
}