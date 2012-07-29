using System;
using System.Collections.Generic;
using FluentValidation;

public static class ValidationFactory
{
    static Dictionary<RuntimeTypeHandle, IValidator> validators = new Dictionary<RuntimeTypeHandle, IValidator>();

    public static IValidator GetValidator(Type modelType)
    {
        IValidator validator;
        if (!validators.TryGetValue(modelType.TypeHandle, out validator))
        {
            var typeName = modelType.Name + "Validator";
            var type = Type.GetType(modelType.Namespace + "." + typeName, true);
            validator = (IValidator)Activator.CreateInstance(type);
        }

        return validator;
    }
}