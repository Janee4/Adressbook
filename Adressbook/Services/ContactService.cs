using Addressbook.Interfaces;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace Addressbook.Services;


/// <summary>
/// ContactService hanterar allt som rör kontakter och deras lagring
/// </summary>


public class ContactService : IContactService
{
    //Skapa en lista för att lagra kontakter:
    private static List<IContact> contacts = new List<IContact>();
    private const string JsonFileName = "contacts.json"; // Namnet på JSON-filen

    public void SaveContactsToJsonFile()
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(contacts);

            File.WriteAllText(JsonFileName, jsonString);

            Console.WriteLine("Contacts saved to JSON file.");
        }
        catch 
        {
            Console.WriteLine("Error saving contacts to JSON file");
        
   
        
        }
  
    }
    public ContactService()
    {
        LoadContactsFromJsonFile();
    }

    private void LoadContactsFromJsonFile()
    {
        try
        {
            if (File.Exists(JsonFileName))
            {
                string jsonString = File.ReadAllText(JsonFileName);

                contacts = JsonSerializer.Deserialize<List<IContact>>(jsonString);

                Console.WriteLine("Contacts loaded from JSON file.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading contacts from JSON file: {ex.Message}");
        }
    }


    /*Lägg till en kontakt i listan genom AddContact-metoden. När användaren fyllt i alla uppgifter om kontakten i "AddContactOption-metoden" inuti "MenuService.cs" så 
   * anropas slutligen"AddContact-metoden" i ContactService.
   * Denna metoden tar emot en IContact-instans och lägger till den i vår "contacts-lista" och därmed vår "adressbok".*/
    public void AddContact(IContact contact)
    {
        contacts.Add(contact);
        Console.WriteLine("Contact added successfully!");
        Console.ReadKey(); // Vänta på användarens input innan du går tillbaka till menyn

    }


    /// <summary>
    /// Vi använder oss av LINQ metoden FirstOrDefault som kommer att söka igenom listan "contacts" och jämföra den email-adressen användaren skrivit in 
    /// och som sparats i variabeln "emailToRemove".mot de email adresser som finns i listan.
    ///  Om email adressen hittas kommer email adressen att tilldelas till variabeln "contactToRemove" av datatypen "IContact".
    ///  Om email adressen inte hittas, kommer contactToRemove att sättas till ett default värde (null i detta fallet då datatypen är "IContact").
    ///  Om email adressen matchar "contactToRemove" (dvs inte är null) så kommer den inuti if-satsen att tas bort ur listan "contacts" med hjälp av "remove" metoden 
    ///  och då returneras värdet "true" som indikation på att metoden lyckats. Om email adressen ej hittas, så returneras "false".
    /// </summary>

    public bool RemoveContact(string emailToRemove)
    {
        // Använd LINQ för att söka efter kontakten med matchande e-postadress
        IContact contactToRemove = contacts.FirstOrDefault(c => c.Email == emailToRemove)!;

        if (contactToRemove != null)
        {
            contacts.Remove(contactToRemove);
            return true; // Returnera true för att indikera att kontakten har tagits bort
        }
        else
        {
            return false; // Returnera false för att indikera att ingen kontakt hittades med den angivna e-postadressen
        }
    }

    public List<IContact> GetAllContacts()
    {

        return contacts;

    }

    public IContact GetContact(string emailToShow)
    {
        IContact contactToShow = contacts.FirstOrDefault(c => c.Email == emailToShow);

        if (contactToShow != null)
        {
            Console.WriteLine(contactToShow);
            return contactToShow;
        }
        else
        {
            Console.WriteLine("Sorry could not find contact");
            return null;
        }
    }
}



/* HASSES KOMMENTAR
 
När du använder dig av interface och du ska använda dig av JsonConvert så måste du göra en sak
  
  var settings = new JsonSerializerSettings 
  {
      TypeNameHandling = TypeNameHandling.All
  }
  
  När du ska göra det till json för att spara ner till filen
  var json = JsonConvert.SerializeObject(_contacts, settings);

  När du vill hämta upp infomrationen från filen och göra det till en lista 
  _contacts = JsonConvert.DeserializeObject<List<IContact>>(contentFromFile, settings);


 
 */