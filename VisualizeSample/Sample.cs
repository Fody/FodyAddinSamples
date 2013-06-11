using System.Diagnostics;
using NUnit.Framework;

[TestFixture]
public class VisualizeSample
{
    [Test]
    public void Run()
    {
        var person = new Person
                     {
                         FamilyName = "Smith", 
                         GivenNames = "John James"
                     };
        //Set a breakpoint here and look at person int he debugger
        Debug.WriteLine(person);
    }

}
public class Person 
{
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