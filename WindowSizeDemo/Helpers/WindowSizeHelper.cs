using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;

namespace WindowSizeDemo.Helpers;

public static class WindowSizeHelper
{
    private static bool TryGetPresenter(Window window, out OverlappedPresenter? presenter, out double scale)
    {
        scale = 1; 
        presenter = window?.AppWindow?.Presenter as OverlappedPresenter;
        if (window?.Content is not FrameworkElement content || content.XamlRoot is null || presenter is null) return false;
        scale = content.XamlRoot.RasterizationScale;
        return true;
    }

    public static void SetPreferredMinimumWidth(Window window, double width)
    {
        if (TryGetPresenter(window, out var presenter, out var scale) && presenter != null)
        {
            presenter.PreferredMinimumWidth = (int)(width * scale);
        }
    }

    public static void SetPreferredMinimumHeight(Window window, double height)
    {
        if (TryGetPresenter(window, out var presenter, out var scale) && presenter != null)
        {
            presenter.PreferredMinimumHeight = (int)(height * scale);
        }
    }

    public static void SetPreferredMaximumWidth(Window window, double width)
    {
        if (TryGetPresenter(window, out var presenter, out var scale) && presenter != null)
        {
            presenter.PreferredMaximumWidth = (int)(width * scale);
        }
    }

    public static void SetPreferredMaximumHeight(Window window, double height)
    {
        if (TryGetPresenter(window, out var presenter, out var scale) && presenter != null)
        {
            presenter.PreferredMaximumHeight = (int)(height * scale);
        }
    }
}
