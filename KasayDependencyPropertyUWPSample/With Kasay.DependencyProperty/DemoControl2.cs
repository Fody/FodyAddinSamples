using Kasay.DependencyProperty;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

public sealed partial class DemoControl2 : UserControl
{
    [Bind] public Brush BackgroundCircle { get; set; }

    [Bind] public string TextCircle { get; set; }

    [Bind] public string Title { get; set; }

    [Bind] public string Description { get; set; }
}
