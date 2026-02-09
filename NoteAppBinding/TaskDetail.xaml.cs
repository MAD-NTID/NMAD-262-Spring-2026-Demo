namespace NoteAppBinding;

public partial class TaskDetail : ContentPage
{
	public TaskDetail(ToDo todo)
	{
		InitializeComponent();

		BindingContext = todo;
		
	}
}