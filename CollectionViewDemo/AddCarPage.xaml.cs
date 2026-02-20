using System.Collections.ObjectModel;

namespace CollectionViewDemo;

public partial class AddCarPage : ContentPage
{
	private Car car;
	private ObservableCollection<Car> cars;
	
	public AddCarPage(ObservableCollection<Car> cars)
	{
		if(car is null)
			car = new Car();
		
		
		InitializeComponent();
		this.cars = cars;
		this.cars = cars;
		BindingContext = car;

		
	}

	public async void SaveCar(object? sender, EventArgs e)
	{

		await DisplayAlertAsync("Car Info", car.ToString(), "OK");
		//validate the car properties before saving
		if(string.IsNullOrWhiteSpace(car.Make))
		{
			await DisplayAlertAsync("try", "again", "OK");
			return;
			
		}

		cars.Add(car);

		//update the storage with the new list of cars
		await Storage.Save(cars.ToList());
		await Navigation.PopAsync();
		
	}



}