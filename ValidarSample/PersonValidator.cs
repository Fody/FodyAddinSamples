using FluentValidation;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.FamilyName).NotEmpty();
        RuleFor(x => x.GivenNames).NotEmpty();
    }
}