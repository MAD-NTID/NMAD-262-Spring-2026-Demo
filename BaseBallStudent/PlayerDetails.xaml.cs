namespace BaseBallStudent;

public partial class PlayerDetails : ContentPage
{
	private Player player;
	public PlayerDetails(Player player)
	{
		InitializeComponent();
		this.player = player;

		// You can use this approach if you dont want to 
		// add a new property to the Player class
		// if(player is Pitcher)
		// {
		// 	Pitcher.IsVisible = true;
		// }
		// else if(player is Batter)
		// {
		// 	Batter.IsVisible = true;
		// }

		if(player.pitcherOrBatter == "Pitcher")
		{
			Pitcher.IsVisible = true;
		}
		else if(player.pitcherOrBatter == "Batter")
		{
			Batter.IsVisible = true;
		}
		BindingContext = player;
	}
}