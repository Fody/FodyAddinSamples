using System;
using System.ComponentModel;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;

public class ValidationTemplate : IDataErrorInfo
{
    INotifyPropertyChanged target;

    public ValidationTemplate(INotifyPropertyChanged target)
    {
        this.target = target;
        validator = ValidationFactory.GetValidator(target.GetType());
        validationResult = validator.Validate(target);
        target.PropertyChanged += Validate;
    }

    void Validate(object sender, PropertyChangedEventArgs e)
    {
        if (validator != null)
        {
            validationResult = validator.Validate(target);
        }
    }

    IValidator validator;
    ValidationResult validationResult;

    public string Error
    {
        get
        {
            var strings = validationResult.Errors.Select(x => x.ErrorMessage)
                .ToArray();
            return string.Join(Environment.NewLine, strings);
        }
    }

    public string this[string propertyName]
    {
        get
        {
            var strings = validationResult.Errors.Where(x => x.PropertyName == propertyName)
                .Select(x => x.ErrorMessage)
                .ToArray();
            return string.Join(Environment.NewLine, strings);
        }
    }
}