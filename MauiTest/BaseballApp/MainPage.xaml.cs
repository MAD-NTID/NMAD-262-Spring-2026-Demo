using System.Collections.ObjectModel;

namespace BaseballApp;

public partial class MainPage : ContentPage
{
	int count = 0;
	public ObservableCollection<Player> Players{get;set;}
	private Player? selectedPlayer;
	public Player? SelectedPlayer 
	{
		 get{return selectedPlayer;}
		set
		{
			if(selectedPlayer == value || value == null)
				return;
			
			selectedPlayer = value;
			this.NavigateToDetail(selectedPlayer);

			
		}
	}

	public MainPage()
	{
		InitializeComponent();
		this.Players = new ObservableCollection<Player>();

		//this is good for testing but after that you need to load from storage
		// this.Players =
        // [
        //     //sample datas
        //     new Pitcher { Name = "John Doe", JerseyNumber = 12, Team = "Yankees", ERA = 3.50, Strikeouts = 150, PitchSpeed = 95.5,
		// 	ImageUrl="https://www.baseballamerica.com/wp-content/uploads/2024/04/Ronald_Acuna_KevinDLilesGetty.jpg" },
        //     new Batter { Name = "Jane Smith", JerseyNumber = 34, Team = "Red Sox", BattingAverage = 0.320, HomeRuns = 25, RBIs = 80 },
        //     new Pitcher { Name = "Mike Johnson", JerseyNumber = 45, Team = "Dodgers", ERA = 2.80, Strikeouts = 200, PitchSpeed = 98.0 },
        //     new Batter { Name = "Emily Davis", JerseyNumber = 22, Team = "Cubs", BattingAverage = 0.290, HomeRuns = 18, RBIs = 60 },
        // ];

		//setup the binding context 
		BindingContext = this;
	}

	private async void NavigateToDetail(Player player)
	{
		if(SelectedPlayer != null)
		{
			await Navigation.PushAsync(new PlayerDetail(SelectedPlayer));
			selectedPlayer = null; // reset selection after navigating
			
		}
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		//utilize the mainthread
		MainThread.BeginInvokeOnMainThread(async () =>
		{
			//clear any previous 
			Players.Clear();
			
			//load the players from storage and add them to the observable collection
			List<Player> loadedPlayers = await Storage.LoadAsync();
			foreach(var player in loadedPlayers)
			{
				Players.Add(player);
			}
		});

	}

	public async void AddNewPlayer(object sender, EventArgs e)
	{
		//navigate to the add new player page and pass the Players collection so the new player can be added to it
		await Navigation.PushAsync(new AddNewPlayer(Players));
	}

}
