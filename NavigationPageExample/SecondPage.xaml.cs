namespace NavigationPageExample;
public partial class SecondPage:ContentPage
{
    private string name;
    public SecondPage()
    {
        InitializeComponent();
    }
    public SecondPage(string name)
    {
        this.name = name;
        InitializeComponent();
        Greeting.Text = $"Hello {name}";
    }

    private async void GoToFirstPage(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

        private async void ThirdPage(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new ThirdPage());
    }

   
}