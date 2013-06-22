using System.ComponentModel;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class PublicizeSample
{
    [Test]
    public void Run()
    {
        var targetType = typeof (Target);

        Assert.IsTrue(targetType.IsPublic);
        var typeAttribute = GetEditorBrowsableAttribute(targetType);
        Assert.IsNotNull(typeAttribute);
        Assert.AreEqual(EditorBrowsableState.Advanced, typeAttribute.State);

        var methodInfo = targetType.GetMethod("Method");
        Assert.IsTrue(methodInfo.IsPublic);
        var methodAttribute = GetEditorBrowsableAttribute(methodInfo);
        Assert.IsNotNull(methodAttribute);
        Assert.AreEqual(EditorBrowsableState.Advanced, methodAttribute.State);
    }

    EditorBrowsableAttribute GetEditorBrowsableAttribute(MemberInfo memberInfo)
    {
        return (EditorBrowsableAttribute)memberInfo.GetCustomAttributes(typeof(EditorBrowsableAttribute), false).First();
    }
}

class Target
{
// ReSharper disable UnusedMember.Local
    void Method()
// ReSharper restore UnusedMember.Local
    {
        
    }
}