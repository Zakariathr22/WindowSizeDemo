using Microsoft.UI.Xaml;
using WindowSizeDemo.Helpers;

namespace WindowSizeDemo;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        if (Content is FrameworkElement content)
        {
            content.Loaded += (_, _) =>
            {
                ApplyWindowSizeLimits();
                content.XamlRoot.Changed += (_, _) => ApplyWindowSizeLimits();
            };
        }
    }

    private void ApplyWindowSizeLimits()
    {
        WindowSizeHelper.SetPreferredMinimumWidth(this, 400);
        WindowSizeHelper.SetPreferredMinimumHeight(this, 300);
        WindowSizeHelper.SetPreferredMaximumWidth(this, 800);
        WindowSizeHelper.SetPreferredMaximumHeight(this, 600);
    }
}
