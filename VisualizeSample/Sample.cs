using System.Diagnostics;
using Xunit;

public class VisualizeSample
{
    [Fact]
    public void Run()
    {
        var person = new Person
                     {
                         FamilyName = "Smith",
                         GivenNames = "John James"
                     };
        //Set a breakpoint here and look at person in the debugger
        Trace.WriteLine(person);
    }
}

public class Person
{
    public string GivenNames { get; set; }
    public string FamilyName { get; set; }

    public string FullName => $"{GivenNames} {FamilyName}";
}