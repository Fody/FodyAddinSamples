using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Xunit;

public class PublicizeSample
{
    [Fact]
    public void Run()
    {
        var targetType = typeof (PublicizeTarget);

        Assert.True(targetType.IsPublic);
        var typeAttribute = GetEditorBrowsableAttribute(targetType);
        Assert.NotNull(typeAttribute);
        Assert.Equal(EditorBrowsableState.Advanced, typeAttribute.State);

        var methodInfo = targetType.GetMethod("Method");
        Assert.True(methodInfo.IsPublic);
        var methodAttribute = GetEditorBrowsableAttribute(methodInfo);
        Assert.NotNull(methodAttribute);
        Assert.Equal(EditorBrowsableState.Advanced, methodAttribute.State);
    }

    EditorBrowsableAttribute GetEditorBrowsableAttribute(MemberInfo memberInfo)
    {
        return (EditorBrowsableAttribute)memberInfo.GetCustomAttributes(typeof(EditorBrowsableAttribute), false).First();
    }
}