using System;
using BaseballApp;
using BaseballApp.ViewModels;

namespace Tests;

public class PlayerDetailViewModelTest
{
    [Fact]
    public void TestConstructorInitializesPlayer()
    {
        // Arrange
        Player player = new Player { Name = "Test Player", JerseyNumber = 99 };

        // Act
        PlayerDetailViewModel viewModel = new PlayerDetailViewModel(player);

        // Assert
        Assert.NotNull(viewModel.Player);
        Assert.Equal(player, viewModel.Player);
    }

    [Fact]
    public void TestIsBatterReturnsTrueForBatter()
    {
        // Arrange
        Player player = new Batter { Name = "Batter", JerseyNumber = 1 };

        // Act
        PlayerDetailViewModel viewModel = new PlayerDetailViewModel(player);

        // Assert
        Assert.True(viewModel.IsBatter);
    }

    [Fact]
    public void TestIsBatterReturnsFalseForNonBatter()
    {
        // Arrange
        Player player = new Pitcher { Name = "Pitcher", JerseyNumber = 2 };

        // Act
        PlayerDetailViewModel viewModel = new PlayerDetailViewModel(player);

        // Assert
        Assert.False(viewModel.IsBatter);
    }

    [Fact]
    public void TestIsPitcherReturnsTrueForPitcher()
    {
        // Arrange
        Player player = new Pitcher { Name = "Pitcher", JerseyNumber = 2 };

        // Act
        PlayerDetailViewModel viewModel = new PlayerDetailViewModel(player);

        // Assert
        Assert.True(viewModel.IsPitcher);
    }

}
