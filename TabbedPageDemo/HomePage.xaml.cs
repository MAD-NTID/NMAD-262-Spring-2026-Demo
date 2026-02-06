namespace TabbedPageDemo;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

	private async void OnClickButton(object? sender, EventArgs e)
	{
		await Navigation.PushAsync(new Settings());
	}
}