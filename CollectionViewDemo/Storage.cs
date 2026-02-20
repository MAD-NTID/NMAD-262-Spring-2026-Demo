using Newtonsoft.Json;

public static class Storage
{
  private static readonly string filename = "cars.json";
  private static readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, filename); 


  /**
  This method will load the json object from the file
  */
  public static async Task<List<Car>> LoadAsync()
  {
    //the file doesnt exist so we will just return a empty list 
    if (!File.Exists(filePath))
    {
       return new List<Car>(); 
    }

    //Use the stream reader to read in the data from the file
    StreamReader reader =  new StreamReader(filePath);

    //read in the entire json string
    string carJsonData = reader.ReadToEnd();

    //close the reader
    reader.Close();

    //convert the full json string to C# object with the deserialize object
    List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(carJsonData);

    //return the cars object
    return cars;
  }

  public static async Task Save(List<Car> cars)
  {

    //do nothing if the list is empty
    if(cars.Count == 0)
        return ; // do nothing

    //use the streamwriter to write to the file
    StreamWriter writer = new StreamWriter(filePath);

    //convert the cars objects to a JSON string representation
    string jsonCars = JsonConvert.SerializeObject(cars);
    
    writer.WriteAsync(jsonCars);
    writer.FlushAsync();

    //close the writer when you are done
    writer.Close();
        
  }
}