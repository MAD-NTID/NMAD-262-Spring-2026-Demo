using System.ComponentModel;

namespace BaseballApp;

public partial class PlayerDetail : ContentPage, INotifyPropertyChanged
{
	public  Player Player{get;set;}

	//two different way to use property to determine if the player is a pitcher or batter
	//long way
	public bool IsPitcher
	{
		get
		{
			return Player is Pitcher;
		}
	}

	//short way using lamda expression
	public bool IsBatter => Player is Batter;

	public PlayerDetail(Player player)
	{
		InitializeComponent();
		this.Player = player;


		// set the binding context to the player object
		BindingContext = this;
		
		// //notify the UI that the player has changed so it can update the visibility of the stat sections
		// OnPropertyChanged(nameof(IsPitcher));
		// OnPropertyChanged(nameof(IsBatter));
	}

	public async void OnBackButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}