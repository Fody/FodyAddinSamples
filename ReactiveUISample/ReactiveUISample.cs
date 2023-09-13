using System;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using Xunit;

public class ReactiveUiSample
{
    [Fact]
    public void Run()
    {
        var target = new ReactiveViewModel();
        var notificationOccured = false;
        target.WhenAnyValue(_ => _.Property).Subscribe(_ => notificationOccured = true);
        Assert.True(notificationOccured);
    }

    public IEnableLogger Foo { get; set; }

    public class ReactiveViewModel :
        ReactiveObject
    {
        [Reactive]
        public string Property { get; set; }
    }
}