using System;
using System.ComponentModel;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;

namespace ValidarSample
{
    public class ValidationTemplate<T> :
        IDataErrorInfo where T: INotifyPropertyChanged
    {
        public ValidationTemplate(T target)
        {
            validator = ValidationFactory.GetValidator(target.GetType());
            context = new ValidationContext<T>(target);
            result = validator.Validate(context);
            target.PropertyChanged += Validate;
        }

        void Validate(object sender, PropertyChangedEventArgs e)
        {
            if (validator != null)
            {
                result = validator.Validate(context);
            }
        }

        IValidator validator;
        ValidationResult result;
        ValidationContext<T> context;

        public string Error
        {
            get
            {
                var strings = result.Errors
                    .Select(x => x.ErrorMessage);
                return string.Join(Environment.NewLine, strings);
            }
        }

        public string this[string propertyName]
        {
            get
            {
                var strings = result.Errors
                    .Where(x => x.PropertyName == propertyName)
                    .Select(x => x.ErrorMessage);
                return string.Join(Environment.NewLine, strings);
            }
        }
    }
}