using System.Linq;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Win2D;
using Microsoft.Maui.Handlers;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MauiVideoTest.Platforms.Windows;
using LibVLCSharp.Platforms.UWP;
using LibVLCSharp.Shared;

namespace MauiVideoTest
{
    public partial class VideoOverlay
    {
        Microsoft.UI.Xaml.Controls.Frame? _frame;
        Panel? _panel;
        FrameworkElement? _nativeElement;

        public bool Initialize()
        {
            if (IsNativeViewInitialized)
                return true;

            if (Window?.Content == null)
                return false;

            _nativeElement = Window.Content.GetNative(true);
            if (_nativeElement == null)
                return false;
            var handler = Window.Handler as WindowHandler;
            if (handler?.NativeView is not Microsoft.UI.Xaml.Window _window)
                return false;
            var videoView = new VideoView() { MediaPlayer = this.MediaPlayer };
            var grid = new Microsoft.UI.Xaml.Controls.Grid();
            grid.Children.Add(videoView);
            _panel?.Children.Add(grid);
            
            return this.IsNativeViewInitialized = true;
        }

        void DeinitializeNativeDependencies()
        {
        }
    }
}
