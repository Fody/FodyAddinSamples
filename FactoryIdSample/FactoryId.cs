using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryId
{
	[System.AttributeUsage(System.AttributeTargets.Class,AllowMultiple=false,Inherited=false)]
	public class FactoryIntKeyAttribute:Attribute
	{
		public int Key { get; set; }
		public FactoryIntKeyAttribute(int key)
		{
			Key = key;
		}
	}
	[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class FactoryStrKeyAttribute : Attribute
	{
		public String Key { get; set; }
		public FactoryStrKeyAttribute(string key)
		{
			Key = key;
		}
	}
	[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class FactoryIntBaseAttribute : Attribute
	{
	}
	[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class FactoryStrBaseAttribute : Attribute
	{
	}
	public class FactoryIntBaseAutoAttribute : Attribute
	{
		public Type Conversion { get; set; }
		public FactoryIntBaseAutoAttribute(Type conversion) { Conversion = conversion; }
	}
	[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class FactoryStrBaseAutoAttribute : Attribute
	{
	}

	[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class FactoryExcludeAttribute : Attribute
	{
	}

}
