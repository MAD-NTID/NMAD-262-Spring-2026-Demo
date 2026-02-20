using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CollectionViewDemo;

public partial class MainPage : ContentPage,INotifyPropertyChanged
{


	public ObservableCollection<Car> Cars {get;set;} = new ObservableCollection<Car>();
	private Car selectedCar;
	public event PropertyChangedEventHandler PropertyChanged;

	 private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

	public Car SelectCar
	{
		get{return selectedCar;}
		set
		{
			if(selectedCar==value)
				return;
			
			selectedCar=value;
			NotifyPropertyChanged();
			NavigateToCarDetail(selectedCar);

			///App.Current.MainPage.DisplayAlert("Selected Car", $"{selectedCar.Make} {selectedCar.Model}", "OK");
		}
	}
	
	public MainPage()
	{
		InitializeComponent();

		//long way

		// Car ford = new Car
		// {
		// 	ImageUrl = "https://e7.pngegg.com/pngimages/575/847/png-clipart-ford-ranger-ford-everest-ford-motor-company-car-ford-car-pickup-truck.png",
		// 	Make = "Ford",
		// 	Model = "Mustang GT",
		// 	Year = 2018
		// };

		// Car chevy = new Car
		// {
		// 	ImageUrl = "https://e7.pngegg.com/pngimages/925/433/png-clipart-yellow-chevrolet-coupe-chevrolet-camaro-car-chevrolet-chevelle-chevrolet-tahoe-yellow-camaro-hd-performance-car-vehicle-thumbnail.png",
		// 	Make = "Chevrolet",
		// 	Model = "Camaro SS",
		// 	Year = 2019
		// };

		// Cars.Add(ford);
		// Cars.Add(chevy);

		//simpify
		// Cars.Add(new Car
		// {
		// 	ImageUrl = "https://e7.pngegg.com/pngimages/575/847/png-clipart-ford-ranger-ford-everest-ford-motor-company-car-ford-car-pickup-truck.png",
		// 	Make = "Ford",
		// 	Model = "Mustang GT",
		// 	Year = 2018,
		// 	Cost=35000,
		// 	Color="Grey",
		// 	IsNew=false
		// });

		// Cars.Add(new Car
		// {
		// 	ImageUrl = "https://e7.pngegg.com/pngimages/925/433/png-clipart-yellow-chevrolet-coupe-chevrolet-camaro-car-chevrolet-chevelle-chevrolet-tahoe-yellow-camaro-hd-performance-car-vehicle-thumbnail.png",
		// 	Make = "Chevrolet",
		// 	Model = "Camaro SS",
		// 	Year = 2019,
		// 	Cost=37000,
		// 	Color="Yellow",
		// 	IsNew=true
		// });
		 

		BindingContext = this;

		
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();


		MainThread.BeginInvokeOnMainThread(async () =>
		{
			//clear out any previous cars
			Cars.Clear();

			List<Car> carsFromStorage = await Storage.LoadAsync();

			//loop through list of cars from the storage and add them to the observable cars
			foreach(Car car in carsFromStorage)
			{
				Cars.Add(car);
			}
		});
    }

	private async void NavigateToCarDetail(Car car)
	{
		//await DisplayAlertAsync("Selected Car", $"{car.Make} {car.Model}", "OK");
		await Navigation.PushAsync(new CarDetailPage(car));

		//go to nagivate to a new page
	}

	public async void AddNewCarPage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddCarPage(Cars));
	}

	public async void TakePhoto(object? sender, EventArgs e)
	{

		//check if permission was granted
		var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
		if(status != PermissionStatus.Granted)
		{
			//if it was not granted, annoy the user
			status = await Permissions.RequestAsync<Permissions.Camera>();
			return;
		}

		//take the picture
		var result = await MediaPicker.Default.CapturePhotoAsync();
		//check if the picture was taken or if the user cancelled or something goes wrong
		if(result == null)
		{
			await DisplayAlertAsync("No Photo", "Photo capture was cancelled.", "OK");
			return;
		}

		//show the path where the photo was saved
		await DisplayAlertAsync("Photo Taken", $"Photo saved to {result.FullPath}", "OK");

		// if(result != null)
		// {
		// 	var stream = await result.OpenReadAsync();
		// 	await DisplayAlertAsync("Photo Taken", $"Photo saved to {result.FullPath}", "OK");
		// }
		// else
		// {
		// 	await DisplayAlertAsync("No Photo", "Photo capture was cancelled.", "OK");
		// }
	}


}
