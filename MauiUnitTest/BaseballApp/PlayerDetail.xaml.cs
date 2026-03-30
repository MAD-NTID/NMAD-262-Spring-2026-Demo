using System.ComponentModel;
using BaseballApp.ViewModels;

namespace BaseballApp;

public partial class PlayerDetail : ContentPage
{
	public PlayerDetailViewModel ViewModel;

	public PlayerDetail(Player player)
	{
		ViewModel = new PlayerDetailViewModel(player);
		InitializeComponent();

		// set the binding context to the player object
		BindingContext = ViewModel;
		
	}

	public async void OnBackButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}