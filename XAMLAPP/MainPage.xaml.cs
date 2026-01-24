namespace XAMLAPP;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		//InitializeComponent();

		//creating the vertical stack layout
		Layout verticalStack = new VerticalStackLayout();

		//creating label 1
		Label label1 = new Label();
		label1.Text = "Hello World";
		label1.Margin = 20;

		//add label 1 to vertical stack
		verticalStack.Children.Add(label1);

		//add the butoon
		/*<Button 
            Text="Please CLICK MEEEE" 
            FontSize="20" 
            TextColor="Red" 
            Background="Black"
            CornerRadius="5"
            WidthRequest="250"
            />
			*/

		Button btn1 = new Button();
		btn1.Text = "Please Click ME";
		btn1.FontSize = 50;
		btn1.TextColor=Colors.Red;
		btn1.Background = Colors.Black;
		btn1.CornerRadius = 5;
		btn1.WidthRequest = 250;

		//add to the button to vertical stack
		verticalStack.Children.Add(btn1);


		//add the vertical stack to the content
		this.Content = verticalStack;




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
