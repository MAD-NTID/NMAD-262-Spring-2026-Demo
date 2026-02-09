namespace TabbedPageDemo;

public partial class MainPage : TabbedPage
{
	// int count = 0;

	public MainPage()
	{
		InitializeComponent();

		//setup a new binding with a simple class
		var simple = new Simple { Name = "John Doe" };
		this.BindingContext = simple;
		
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
}
