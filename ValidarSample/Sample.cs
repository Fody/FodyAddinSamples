using System.ComponentModel;
using NUnit.Framework;

[TestFixture]
public class ValidarSample
{
    [Test]
    public void Run()
    {
        var person = new Person();

        // Validar had added and IDataErrorInfo implementation to Person
        var personAsDataErrorInfo = (IDataErrorInfo)person;
        
        //values will be invalid to start with
        Assert.AreEqual("'Given Names' should not be empty.", personAsDataErrorInfo["GivenNames"]);
        Assert.AreEqual("'Family Name' should not be empty.", personAsDataErrorInfo["FamilyName"]);
        
        //Set to some valid values
        person.FamilyName = "Smith";
        person.GivenNames = "John";
        
        Assert.IsEmpty(personAsDataErrorInfo["GivenNames"]);
        Assert.IsEmpty(personAsDataErrorInfo["FamilyName"]);
    }

}

