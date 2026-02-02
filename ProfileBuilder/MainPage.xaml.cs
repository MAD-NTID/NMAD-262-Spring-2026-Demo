namespace ProfileBuilder;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void UpdateNamePreview(object? sender, EventArgs e)
	{
		//get the typed value
		string typed = NameForm.Text;

		//check if empty
		if(string.IsNullOrWhiteSpace(typed))
			return ; //do nothing

		//otherwise we have something so we update the preview
		NamePreview.Text = typed;
	}


}
