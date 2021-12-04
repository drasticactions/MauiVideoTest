using System.Linq;
using Android.App;
using Android.Views;
using AndroidX.CoordinatorLayout.Widget;
using LibVLCSharp.Platforms.Android;
using LibVLCSharp.Shared;
using MauiVideoTest.Platforms.Android;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Native;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace MauiVideoTest
{
    public partial class VideoOverlay
    {
        Activity? _nativeActivity;
        ViewGroup? _nativeLayer;
		VideoView? videoView;

        public bool Initialize()
        {
			if (IsNativeViewInitialized)
				return true;
			
			if (Window == null)
				return false;

			var nativeWindow = Window?.Content?.GetNative(true);
			if (nativeWindow == null)
				return false;

			var handler = Window?.Handler as WindowHandler;
			if (handler?.MauiContext == null)
				return false;
			var rootManager = handler.MauiContext.GetNavigationRootManager();
			if (rootManager == null)
				return false;


			if (handler.NativeView is not Activity activity)
				return false;

			_nativeActivity = activity;
			_nativeLayer = rootManager.RootView as ViewGroup;

			if (_nativeLayer?.Context == null)
				return false;

			if (_nativeActivity?.WindowManager?.DefaultDisplay == null)
				return false;

			var measuredHeight = _nativeLayer.MeasuredHeight;

			if (_nativeActivity.Window != null)
				_nativeActivity.Window.DecorView.LayoutChange += DecorViewLayoutChange;

			//if (_nativeActivity?.Resources?.DisplayMetrics != null)
			//	Density = _nativeActivity.Resources.DisplayMetrics.Density;

			this.videoView = new VideoView(activity) { MediaPlayer = this.MediaPlayer };
			//var layerCount = 0;
			var layerCount = _nativeLayer.ChildCount;
			var childView = _nativeLayer.GetChildAt(1);
			_nativeLayer.AddView(this.videoView, layerCount, new CoordinatorLayout.LayoutParams(CoordinatorLayout.LayoutParams.MatchParent, CoordinatorLayout.LayoutParams.MatchParent));
			// this.videoView.BringToFront();
			childView.BringToFront();
			return this.IsNativeViewInitialized = true;
		}

		/// <summary>
		/// Deinitializes the native event hooks and handlers used to drive the overlay.
		/// </summary>
		void DeinitializeNativeDependencies()
		{
			if (_nativeActivity?.Window != null)
				_nativeActivity.Window.DecorView.LayoutChange -= DecorViewLayoutChange;
			this.videoView?.Dispose();
			IsNativeViewInitialized = false;
		}

		void DecorViewLayoutChange(object? sender, Android.Views.View.LayoutChangeEventArgs e)
		{
			HandleUIChange();
			Invalidate();
		}
	}
}
