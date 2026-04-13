namespace Tests;
using BaseballApp;
using BaseballApp.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MainPageViewModelTest
{
    [Fact]
    public void TestConstructorInitalizesPlayers()
    {
        // Arrange & Act
        var viewModel = new MainPageViewModel();

        // Assert
        Assert.NotNull(viewModel.Players);
        Assert.Empty(viewModel.Players);
    }

    [Fact]
    public void TestSelectedPlayerTriggersEventValid()
    {
        MainPageViewModel vm = new MainPageViewModel();
        Player player = new Player { Name = "Test", JerseyNumber = 1 };

        bool eventTriggered = false;

        //mimic the event fired in the view when the selected player is set in the view model
        vm.OnPlayerSelected += (selectedPlayer) =>
        {
            eventTriggered = true;
            Assert.Equal(player, selectedPlayer);
        };

        vm.SelectedPlayer = player;

        Assert.True(eventTriggered);
    }

    [Fact]
    public void TestSelectedPlayerDoesNotTriggerEventWhenNull()
    {
        MainPageViewModel vm = new MainPageViewModel();

        bool eventTriggered = false;
        //mimic the event fired in the view when the selected player is set in the view model
        vm.OnPlayerSelected += (selectedPlayer) =>
        {
            eventTriggered = true;
            //assert that the selected is null
            Assert.Null(selectedPlayer);
        };

        vm.SelectedPlayer = null;

        Assert.False(eventTriggered);
    }

    [Fact]
    public async Task TestSelectingPlayerAgainDoesNotTriggerEvent()
    {
        MainPageViewModel vm = new MainPageViewModel();
        Player player = new Player { Name = "Test", JerseyNumber = 1 };
        int count = 0;

        bool eventTriggered = false;

        //mimic the event fired in the view when the selected player is set in the view model
        vm.OnPlayerSelected += (selectedPlayer) =>
        {
            eventTriggered = true;
            Assert.Equal(player, selectedPlayer);
            count++;
        };

        vm.SelectedPlayer = player;
        vm.SelectedPlayer = player; // same again

        //ensure that the event is only triggered once
        Assert.Equal(1, count);
        Assert.Equal(player, vm.SelectedPlayer); 
    }

    [Fact]
    public async Task TestLoadPlayersAsync()
    {
        MainPageViewModel vm = new MainPageViewModel();
        
        //we cant use appdata because we are not using MAUI app
        string testDirectory = Path.GetTempPath(); // Use temporary directory for testing

        Storage.Init(testDirectory); // Initialize storage with a test directory
        //storage file path
        string storagePath = Storage.filePath;

        //clear the storage if it exists
        if(File.Exists(storagePath))
        {
            File.Delete(storagePath);
        }

        //create our own tested player data to be loaded in the storage
        List<Player> fakePlayers = new List<Player>
        {
            new Player { Name = "Player 1", JerseyNumber = 1 },
            new Player { Name = "Player 2", JerseyNumber = 2 }
        };

        //save our data to the storage file
        await Storage.Save(fakePlayers);

        //now we can load the data from the storage using the view model method and test if it is loaded correctly
        await vm.LoadPlayersAsync();

        Assert.Equal(2, vm.Players.Count);
        Assert.Equal("Player 1", vm.Players[0].Name);
        Assert.Equal("Player 2", vm.Players[1].Name);
    }

}
