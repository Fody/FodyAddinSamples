using System;

namespace FactoryId
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class FactoryIntKeyAttribute : Attribute
    {
        public int Key { get; set; }

        public FactoryIntKeyAttribute(int key)
        {
            Key = key;
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class FactoryStrKeyAttribute : Attribute
    {
        public string Key { get; set; }

        public FactoryStrKeyAttribute(string key)
        {
            Key = key;
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class FactoryIntBaseAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class FactoryStrBaseAttribute : Attribute
    {
    }

    public class FactoryIntBaseAutoAttribute : Attribute
    {
        public Type Conversion { get; set; }

        public FactoryIntBaseAutoAttribute(Type conversion)
        {
            Conversion = conversion;
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class FactoryStrBaseAutoAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class FactoryExcludeAttribute : Attribute
    {
    }
}