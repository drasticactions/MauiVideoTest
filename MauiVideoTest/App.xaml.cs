namespace MauiVideoTest;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
		return new VideoWindow() { Page = new MainPage() };
    }
}