using System;
using System.Collections.Generic;
using FluentValidation;

public static class ValidationFactory
{
    static Dictionary<RuntimeTypeHandle, IValidator> validators = new Dictionary<RuntimeTypeHandle, IValidator>();

    public static IValidator GetValidator(Type modelType)
    {
        if (!validators.TryGetValue(modelType.TypeHandle, out var validator))
        {
            var type = modelType.Assembly
                .GetType($"{modelType.Namespace}.{modelType.Name}Validator", true);
            validator = (IValidator)Activator.CreateInstance(type);
            validators[modelType.TypeHandle] = validator;
        }

        return validator;
    }
}