using System;
using Microsoft.UI.Xaml;


namespace MauiVideoTest.Platforms.Windows
{
    public static class HandlerExtensions
    {
		internal static FrameworkElement? GetNative(this IElement view, bool returnWrappedIfPresent)
		{
			if (view.Handler is INativeViewHandler nativeHandler && nativeHandler.NativeView != null)
				return nativeHandler.NativeView;

			return (view.Handler?.NativeView as FrameworkElement);

		}
	}
}
