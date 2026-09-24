using System;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

public class ReactiveUiSample
{
    [Test]
    public async Task Run()
    {
        var target = new ReactiveViewModel();
        var notificationOccured = false;
        target.WhenAnyValue(_ => _.Property).Subscribe(_ => notificationOccured = true);
        await Assert.That(notificationOccured).IsTrue();
    }

    public IEnableLogger Foo { get; set; }

    public class ReactiveViewModel :
        ReactiveObject
    {
        [Reactive]
        public string Property { get; set; }
    }
}