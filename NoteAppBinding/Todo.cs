using System.ComponentModel;
using System.Runtime.CompilerServices; //Needed for CallerMemberName attribute

public class ToDo:INotifyPropertyChanged
{
    private string name;
    private string note;
    public event PropertyChangedEventHandler PropertyChanged;
    public string Name
    {
        get {return name;}
        set
        {
            //if the value is the same as the current value, do nothing
            if(name == value)
            {
                return;
            }

            //otherwise we assign the new value to the name field
            name = value;

            //update the name property
            //this will use the CallerMemberName attribute to automatically pass 
            //the name of the property that called it, which in this case is "Name"
            NotifyPropertyChanged(); 

            //update the character count property
            NotifyPropertyChanged(nameof(CharacterCount));

            //update the IsCreateEnabled property
            NotifyPropertyChanged(nameof(IsCreateEnabled));

        }

    }
    public string Note
    {
        get {return note;}
        set
        {
            //if the value is the same as the current value, do nothing
            if(note == value)
            {
                return;
            }

            //otherwise we assign the new value to the note field
            note = value;

            //update the note property
            NotifyPropertyChanged();

            //update the IsCreateEnabled property
            NotifyPropertyChanged(nameof(IsCreateEnabled));
        }
    }
    public bool IsDone{get;set;}
    public bool IsCreateEnabled
    {
        //return true if both the Name and Note properties have values, otherwise return false
        get
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Note);
        }
    }

    public int CharacterCount
    {
        //return the how many characters are in the Name string
        get
        {
            if(string.IsNullOrWhiteSpace(Name))            {
                return 0;
            }
            else
            {
                return Name.Length;
            }
        }
    }

    //create a method to manage the property changed event callmembers
    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}