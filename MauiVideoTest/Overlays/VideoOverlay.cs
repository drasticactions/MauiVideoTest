using System;
using System.Collections.Generic;
using System.Linq;
using LibVLCSharp.Shared;
using Microsoft.Maui.Graphics;

#if __IOS__ || MACCATALYST
using NativeView = UIKit.UIView;
#elif __ANDROID__
using NativeView = Android.Views.View;
#elif WINDOWS
using NativeView = Microsoft.UI.Xaml.FrameworkElement;
#elif NETSTANDARD
using NativeView = System.Object;
#endif

namespace MauiVideoTest
{
    public partial class VideoOverlay : IWindowOverlay
    {
        public VideoOverlay (LibVLCSharp.Shared.LibVLC libVLC, LibVLCSharp.Shared.MediaPlayer mediaPlayer, IWindow window)
        {
            this.LibVLC = libVLC;
            this.MediaPlayer = mediaPlayer;
            this.Window = window;
        }

        internal LibVLCSharp.Shared.LibVLC LibVLC { get; private set; }

        internal LibVLCSharp.Shared.MediaPlayer MediaPlayer { get; private set; }

        public bool DisableUITouchEventPassthrough { get; set; }
        public bool EnableDrawableTouchHandling { get; set; }

        public bool IsVisible { get; set; }

        public IWindow Window { get; }

        public float Density => 0;

        public IReadOnlyCollection<IWindowOverlayElement> WindowElements => new List<IWindowOverlayElement>();

        public bool IsNativeViewInitialized { get; private set; }

        public event EventHandler<WindowOverlayTappedEventArgs> Tapped;

        public bool AddWindowElement(IWindowOverlayElement element)
        {
            return false;
        }

        public bool Deinitialize()
        {
            DeinitializeNativeDependencies();
            return true;
        }

        public void Draw(ICanvas canvas, RectangleF dirtyRect)
        {
        }

        public void HandleUIChange()
        {
        }

        public void Invalidate()
        {
        }

        public bool RemoveWindowElement(IWindowOverlayElement element)
        {
            return false;
        }

        public void RemoveWindowElements()
        {
        }
    }
}
