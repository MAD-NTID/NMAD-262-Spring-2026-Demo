using Newtonsoft.Json;

public static class Storage
{
  private static readonly string filename = "players.json";
  private static readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, filename); 

    private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.All, // include type info
        Formatting = Formatting.Indented
    };


  /**
  This method will load the json object from the file
  */
  public static async Task<List<Player>> LoadAsync()
  {
    //the file doesnt exist so we will just return a empty list 
    if (!File.Exists(filePath))
    {
       return new List<Player>(); 
    }

    //Use the stream reader to read in the data from the file
    StreamReader reader =  new StreamReader(filePath);

    //read in the entire json string
    string playerJsonData = reader.ReadToEnd();

    //close the reader
    reader.Close();

    //convert the full json string to C# object with the deserialize object
    List<Player> players = JsonConvert.DeserializeObject<List<Player>>(playerJsonData, settings);

    //return the players object
    return players;
  }

  public static async Task Save(List<Player> players)
  {

    //do nothing if the list is empty
    if(players.Count == 0)
        return ; // do nothing

    //use the streamwriter to write to the file
    StreamWriter writer = new StreamWriter(filePath);
    
    //convert the players objects to a JSON string representation
    string jsonPlayers = JsonConvert.SerializeObject(players, settings);
    
    await writer.WriteAsync(jsonPlayers);
    await writer.FlushAsync();

    //close the writer when you are done
    writer.Close();

   
        
  }
}