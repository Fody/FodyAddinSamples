using FluentValidation;

namespace ValidarSample;

public class PersonValidator :
    AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(_ => _.FamilyName).NotEmpty();
        RuleFor(_ => _.GivenNames).NotEmpty();
    }
}