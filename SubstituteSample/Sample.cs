using System.Globalization;
using System.Threading;

using SubstituteSample.Properties;

using Xunit;

public class SubstituteSamples
{
    [Fact]
    public void ResourceManager()
    {
        var target = Resources.String1;
        Assert.Equal("Override: String1 => English", target);

        Resources.Culture = CultureInfo.GetCultureInfo("de-DE");

        target = Resources.String1;
        Assert.Equal("Override: String1 => Deutsch", target);
    }

    [Fact]
    public void ComponentResourceManager()
    {
        var target = new SampleForm();

        Assert.Equal("Override: $this.Text => English", target.Text);
        Assert.Equal("Override: label1.Text => Label", target.label1.Text);

        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
        target = new SampleForm();

        Assert.Equal("Override: $this.Text => Deutsch", target.Text);
        Assert.Equal("Override: label1.Text => Textfeld", target.label1.Text);
    }
}
