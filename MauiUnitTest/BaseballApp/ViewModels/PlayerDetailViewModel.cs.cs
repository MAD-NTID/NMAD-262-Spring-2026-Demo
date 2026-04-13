using System;

namespace BaseballApp.ViewModels;

public class PlayerDetailViewModel
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

	public PlayerDetailViewModel(Player player)
	{
		this.Player = player;
	}

}
