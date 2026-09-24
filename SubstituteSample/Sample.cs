using System.Globalization;
using System.Threading;

using SubstituteSample.Properties;


public class SubstituteSamples
{
    [Test]
    public async Task ResourceManager()
    {
        var target = Resources.String1;
        await Assert.That(target).IsEqualTo("Override: String1 => English");

        Resources.Culture = CultureInfo.GetCultureInfo("de-DE");

        target = Resources.String1;
        await Assert.That(target).IsEqualTo("Override: String1 => Deutsch");
    }

    [Test]
    public async Task ComponentResourceManager()
    {
        var target = new SampleForm();

        await Assert.That(target.Text).IsEqualTo("Override: $this.Text => English");
        await Assert.That(target.label1.Text).IsEqualTo("Override: label1.Text => Label");

        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
        target = new SampleForm();

        await Assert.That(target.Text).IsEqualTo("Override: $this.Text => Deutsch");
        await Assert.That(target.label1.Text).IsEqualTo("Override: label1.Text => TextField");
    }
}
