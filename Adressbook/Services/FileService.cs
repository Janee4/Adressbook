
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
        {

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    
}






