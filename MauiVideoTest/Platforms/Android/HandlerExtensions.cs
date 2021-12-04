using System;
using Android.App;
using Android.Content;
using Microsoft.Maui.Platform;
using AView = Android.Views.View;

namespace MauiVideoTest.Platforms.Android
{
    public static class HandlerExtensions
    {
		internal static AView? GetNative(this IElement view, bool returnWrappedIfPresent)
		{
			if (view.Handler is INativeViewHandler nativeHandler && nativeHandler.NativeView != null)
				return nativeHandler.NativeView;

			return (view.Handler?.NativeView as AView);
		}

		public static NavigationRootManager GetNavigationRootManager(this IMauiContext mauiContext) =>
			mauiContext.Services.GetRequiredService<NavigationRootManager>();
	}
}
