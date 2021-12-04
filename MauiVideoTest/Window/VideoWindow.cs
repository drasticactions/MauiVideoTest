using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibVLCSharp.Shared;

namespace MauiVideoTest
{
    public class VideoWindow : Window
    {
        public LibVLC libVLC;
        public LibVLCSharp.Shared.MediaPlayer MediaPlayer { get; private set; }
        private VideoOverlay overlay;

        public VideoWindow()
        {
            LibVLCSharp.Shared.Core.Initialize();
            libVLC = new LibVLC();
            MediaPlayer = new LibVLCSharp.Shared.MediaPlayer(libVLC);
        }

        public void AddVideoOverlay()
        {
            if (this.overlay == null)
                this.overlay = new VideoOverlay(this.libVLC, this.MediaPlayer, this);

            this.AddOverlay(overlay);
        }
    }
}
