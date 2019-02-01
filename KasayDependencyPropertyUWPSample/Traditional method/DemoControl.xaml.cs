namespace Sample.Traditional
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;

    public sealed partial class DemoControl : UserControl
    {
        public static readonly DependencyProperty BackgroundCircleProperty
            = DependencyProperty.Register(
                "BackgroundCircle",
                typeof(Brush),
                typeof(DemoControl),
                null);

        public Brush BackgroundCircle
        {
            get => (Brush)GetValue(BackgroundCircleProperty);
            set => SetValue(BackgroundCircleProperty, value);
        }

        public static readonly DependencyProperty TextCircleProperty
            = DependencyProperty.Register(
                "TextCircle",
                typeof(String),
                typeof(DemoControl),
                null);

        public String TextCircle
        {
            get => (String)GetValue(TextCircleProperty);
            set => SetValue(TextCircleProperty, value);
        }

        public static readonly DependencyProperty TitleProperty
            = DependencyProperty.Register(
                "Title",
                typeof(String),
                typeof(DemoControl),
                null);

        public String Title
        {
            get => (String)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty DescriptionProperty
            = DependencyProperty.Register(
                "Description",
                typeof(String),
                typeof(DemoControl),
                null);

        public String Description
        {
            get => (String)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public DemoControl()
        {
            InitializeComponent();

            DataContext = this;
        }
    }
}
