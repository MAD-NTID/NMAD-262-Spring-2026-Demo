namespace NavigationPageExample;
public partial class MyFirstPage:ContentPage
{
    public MyFirstPage()
    {
        InitializeComponent();
    }

    private async void NextPage(object? sender, EventArgs args)
    {
        string name = NameEntryForm.Text;

        //prevent the user from switching if name is empty
        if(string.IsNullOrWhiteSpace(name))
        {
            string title="Error";
            string message="Please enter your name";
            string cancel="Cancel";
            await DisplayAlertAsync(title, message, cancel);
            return ;
        }

        //every thing is good so they can move forward
        await Navigation.PushAsync(new SecondPage(name));
    }
}