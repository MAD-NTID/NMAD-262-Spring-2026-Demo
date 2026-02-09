

namespace NoteAppBinding;

public partial class MainPage : ContentPage
{
	// int count = 0;
	private ToDo todo;

	public MainPage()
	{
		InitializeComponent();

		//create the data source... AKA the data class or model
		 todo = new ToDo
		{
			Name = "Buy groceries",
			Note = "Milk, Bread, Eggs",
			IsDone = false
		};

		//bind the data source to the context of the page
		BindingContext = todo;



	}

	// private void OnCounterClicked(object? sender, EventArgs e)
	// {
	// 	count++;

	// 	if (count == 1)
	// 		CounterBtn.Text = $"Clicked {count} time";
	// 	else
	// 		CounterBtn.Text = $"Clicked {count} times";

	// 	SemanticScreenReader.Announce(CounterBtn.Text);
	// }

	private async void OnCreateClicked(object sender, EventArgs e)
	{
		if(string.IsNullOrWhiteSpace(todo.Name) || string.IsNullOrWhiteSpace(todo.Note) )
		{
			await DisplayAlertAsync("Error", "Please fill in both the Name and Note fields.", "OK");
			return;
		}

		//push to task detail page
		await Navigation.PushAsync(new TaskDetail(todo));
	}
}
