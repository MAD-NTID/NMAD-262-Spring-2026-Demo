namespace XampEventApp;

public partial class MainPage : ContentPage
{


	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnButtonClicked(object? sender, EventArgs e)
	{
		string title = "Some cool title";
		string message = "The button was clicked!";
		string dismiss = "Close this alert";

		await DisplayAlertAsync(title, message, dismiss);
	}

	private async void OnPressedMagic(object? sender, EventArgs e)
	{
		Button button = (Button)sender;
		button.Text = "Ahhh you pressed me!";
		button.FontSize = 40;
	}

	private void EntryFormCompleted(object? sender, EventArgs e)
	{

		
	

		//get what the user typed from the text property
		string typedData = EntryControlForm.Text;

		//check for empty
		if (string.IsNullOrWhiteSpace(typedData))
		{
			return ; //do nothing
		}

		//Greet the user by hello <name>
		EntryControlForm.Text = "Hello " + typedData;
		ButtonLabel.Text = "Click Me " + typedData;


	}
}
