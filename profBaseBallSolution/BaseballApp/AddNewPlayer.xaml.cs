using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BaseballApp;

public partial class AddNewPlayer : ContentPage,INotifyPropertyChanged
{
	private ObservableCollection<Player> Players{get;set;}

	//this will store the player info from the form
	public Player Player{get;set;}

	//this will watch what the user select from the picker to determine if they are adding a pitcher or batter
	private string selectedPlayerType;
	public string SelectedPlayerType
	{
		get
		{
			return selectedPlayerType;
		}

		set
		{
			if(selectedPlayerType == value)
				return;
			
			selectedPlayerType = value;

			//update the player type properties to control the visibility of the stat fields
			IsPitcher = selectedPlayerType == "Pitcher"; //you can also use if else statement here if you prefer
			IsBatter = selectedPlayerType == "Batter";

			//we need to update the player object to the correct type so we can bind the form fields to it
			if(IsPitcher)
			{
				Player = new Pitcher();
			}
			else if(IsBatter)
			{
				Player = new Batter();
			}

			//notify the UI that the player type has changed so it can update the visibility of the stat sections
			OnPropertyChanged(nameof(Player));
			OnPropertyChanged(nameof(IsPitcher));
			OnPropertyChanged(nameof(IsBatter));
		}
	}

	//this two will be used to decided which field to show
	public bool IsPitcher{get;set;}
	public bool IsBatter{get;set;}
	
	public AddNewPlayer(ObservableCollection<Player> players)
	{
		this.Players = players;

		//we will set the default player type to a batter
		this.Player = new Batter();
		this.SelectedPlayerType = "Batter";

		InitializeComponent();
		BindingContext = this;
	}

	public async void OnAddPlayerClicked(object sender, EventArgs e)
	{
		//add the new player to the collection
		Players.Add(Player);

		//add to the storage
		List<Player> playersToSave = Players.ToList();
		await Storage.Save(playersToSave);

		//navigate back to the main page
		await Navigation.PopAsync();
	}
}