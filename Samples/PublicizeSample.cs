using System.ComponentModel;
using System.Linq;
using System.Reflection;

public class PublicizeSample
{
    [Test]
    public async Task Run()
    {
        var targetType = typeof (PublicizeTarget);

        await Assert.That(targetType.IsPublic).IsTrue();
        var typeAttribute = GetEditorBrowsableAttribute(targetType);
        await Assert.That(typeAttribute).IsNotNull();
        await Assert.That(typeAttribute.State).IsEqualTo(EditorBrowsableState.Advanced);

        var methodInfo = targetType.GetMethod("Method");
        await Assert.That(methodInfo.IsPublic).IsTrue();
        var methodAttribute = GetEditorBrowsableAttribute(methodInfo);
        await Assert.That(methodAttribute).IsNotNull();
        await Assert.That(methodAttribute.State).IsEqualTo(EditorBrowsableState.Advanced);
    }

    static EditorBrowsableAttribute GetEditorBrowsableAttribute(MemberInfo memberInfo) =>
        (EditorBrowsableAttribute)memberInfo.GetCustomAttributes(typeof(EditorBrowsableAttribute), false).First();
}