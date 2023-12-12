using System.Diagnostics;


namespace Addressbook.Services;

public interface IFileService
{

    //ska returnera ett bool värde "jag lyckades spara, eller jag lyckades inte spara" därav bool.
    bool SaveContentToFile(string content);
    //läser upp/hämtar sträng värde
    string GetContentFromFile();


}

public class FileService(string filePath) : IFileService
{
    private readonly string _filePath = filePath;

    public bool SaveContentToFile(string content)
    {
        try
        {
            //StreamWriter vill ha in en sökväg som vi sätter in via vår constructor
            using (var sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(content);
            }
            //Om den lyckas så returneras true
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        //Om den inte lyckas/eller kraschar etc så ska den returnera false
        return false;
    }



    public string GetContentFromFile()
    {
        try
        {   //kollar om filen existerar och om den gör det så 
            if (File.Exists(_filePath))
            {
                using var sr = new StreamReader(_filePath);
                return sr.ReadToEnd();
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }


}






