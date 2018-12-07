using System.ComponentModel;
using Xunit;

public class ValidarSample
{
    [Fact]
    public void Run()
    {
        var person = new Person();

        // Validar had added and IDataErrorInfo implementation to Person
        var personAsDataErrorInfo = (IDataErrorInfo)person;

        //values will be invalid to start with
        Assert.Equal("'Given Names' must not be empty.", personAsDataErrorInfo["GivenNames"]);
        Assert.Equal("'Family Name' must not be empty.", personAsDataErrorInfo["FamilyName"]);

        //Set to some valid values
        person.FamilyName = "Smith";
        person.GivenNames = "John";

        Assert.Empty(personAsDataErrorInfo["GivenNames"]);
        Assert.Empty(personAsDataErrorInfo["FamilyName"]);
    }
}