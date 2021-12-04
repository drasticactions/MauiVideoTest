using LibVLCSharp.Shared;

namespace MauiVideoTest;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnVideoPlay(object sender, EventArgs e)
	{
		this.Background = new SolidColorBrush(Color.FromArgb("33FFFFFF"));
		var window = this.GetParentWindow() as VideoWindow;
		if (window != null)
			window.AddVideoOverlay();

		window.MediaPlayer.Play(new LibVLCSharp.Shared.Media(window.libVLC, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4", FromType.FromLocation));
	}

	private void OnNewWindow(object sender, EventArgs e)
	{
		App.Current.OpenWindow(new VideoWindow() { Page = new MainPage() });
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		CounterLabel.Text = $"Current count: {count}";

		SemanticScreenReader.Announce(CounterLabel.Text);
	}
}

