using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Car:INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private string imageUrl;
    private string make;
    private string model;
    private int year;
    private double cost;
    private string color;


    public string ImageUrl {
        get
        {
            return imageUrl;
        }
         set
        {
            if(imageUrl==value)
                return;
            
            imageUrl=value;
            NotifyPropertyChanged();
        }
         
    }
    public string Make { 
        get{return make;}
        set
        {
            if(make==value)
                return;
            
            make=value;
            NotifyPropertyChanged();
        }
    }
    public string Model { get; set; }
    public int Year { get; set; }
    public double Cost { get; set; }
    public string Color { get; set; }


    public override string ToString()
    {
        return $"{Year} {Make} {Model} - ${Cost}";
    }

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    
}