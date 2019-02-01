namespace Sample
{
    using Kasay.DependencyProperty;
    using System;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;

    public sealed partial class DemoControl : UserControl
    {
        [Bind] public Brush BackgroundCircle { get; set; }

        [Bind] public String TextCircle { get; set; }

        [Bind] public String Title { get; set; }

        [Bind] public String Description { get; set; }

        public DemoControl()
        {
            InitializeComponent();
        }
    }
}
