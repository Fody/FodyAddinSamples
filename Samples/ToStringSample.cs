using System.Diagnostics;
using Xunit;

public class ToStringSample
{
    [Fact]
    public void Run()
    {
        var target = new Person
        {
            GivenNames = "John",
            FamilyName = "Smith"

        };
        Debug.WriteLine(target.ToString());
        Assert.Equal("{T: \"Person\", GivenNames: \"John\", FamilyName: \"Smith\"}", target.ToString());
    }

    [ToString]
    class Person
    {
        public string GivenNames { get; set; }
        public string FamilyName { get; set; }

        [IgnoreDuringToString]
        public string FullName => $"{GivenNames} {FamilyName}";
    }
}