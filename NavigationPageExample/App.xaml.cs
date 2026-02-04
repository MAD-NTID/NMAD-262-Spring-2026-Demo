using Microsoft.Extensions.DependencyInjection;

namespace NavigationPageExample;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new NavigationPage(new MyFirstPage()));
		//return new Window(new AppShell());
	}
}