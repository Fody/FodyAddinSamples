using System.ComponentModel;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class Sample
{
    [Test]
    public void Run()
    {
        var targetType = typeof (Target);

        Assert.IsTrue(targetType.IsPublic);
        var typeAttribue = GetEditorBrowdableAttribute(targetType);
        Assert.IsNotNull(typeAttribue);
        Assert.AreEqual(EditorBrowsableState.Advanced, typeAttribue.State);

        var methodInfo = targetType.GetMethod("Method");
        Assert.IsTrue(methodInfo.IsPublic);
        var methodAttribue = GetEditorBrowdableAttribute(methodInfo);
        Assert.IsNotNull(methodAttribue);
        Assert.AreEqual(EditorBrowsableState.Advanced, methodAttribue.State);
    }

    EditorBrowsableAttribute GetEditorBrowdableAttribute(MemberInfo memberInfo)
    {
        return (EditorBrowsableAttribute)memberInfo.GetCustomAttributes(typeof(EditorBrowsableAttribute), false).First();
    }
}

class Target
{
    void Method()
    {
        
    }
}