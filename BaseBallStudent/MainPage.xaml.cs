using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BaseBallStudent;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;
	private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	public ObservableCollection<Player> Players {get; set;} = new ObservableCollection<Player>();
	private Player selectPlayer;
	public Player SelectPlayer
	{
		get => selectPlayer;
		set
		{
			if(selectPlayer==value)
				return;
			selectPlayer = value;
			NotifyPropertyChanged();
			NavigateToPlayerDetails(selectPlayer);
		}
	}
	public MainPage()
	{
		Players.Add(new Player
		{
			Name = "Uh",
			Team = "idk",
			JerseyNumber=10
		});
		Players.Add(new Pitcher
		{
			Name = "wefg",
			Team = "eagle",
			JerseyNumber=24,
			Win = 1,
			StrikeOut = 1,
			pitcherOrBatter = "Pitcher"
		});
		Players.Add(new Batter
		{
			Name = "ICS",
			Team = "eagle",
			JerseyNumber=13,
			HomeRuns = 1,
			BetterAvg = 10,
			pitcherOrBatter = "Batter"
		});
		
		InitializeComponent();
		BindingContext = this;
	}
	private async void NavigateToPlayerDetails(Player player)
	{
		await Navigation.PushAsync(new PlayerDetails(player));
	}

}
