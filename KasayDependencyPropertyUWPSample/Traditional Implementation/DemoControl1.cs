using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

public sealed partial class DemoControl1 : UserControl
{
    public static readonly DependencyProperty BackgroundCircleProperty
        = DependencyProperty.Register(
            "BackgroundCircle",
            typeof(Brush),
            typeof(DemoControl1),
            null);

    public Brush BackgroundCircle
    {
        get => (Brush)GetValue(BackgroundCircleProperty);
        set => SetValue(BackgroundCircleProperty, value);
    }

    public static readonly DependencyProperty TextCircleProperty
        = DependencyProperty.Register(
            "TextCircle",
            typeof(string),
            typeof(DemoControl1),
            null);

    public string TextCircle
    {
        get => (string)GetValue(TextCircleProperty);
        set => SetValue(TextCircleProperty, value);
    }

    public static readonly DependencyProperty TitleProperty
        = DependencyProperty.Register(
            "Title",
            typeof(string),
            typeof(DemoControl1),
            null);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty DescriptionProperty
        = DependencyProperty.Register(
            "Description",
            typeof(string),
            typeof(DemoControl1),
            null);

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public DemoControl1()
    {
        DataContext = this;
    }
}

