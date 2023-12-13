using System.Collections.Generic;
using Addressbook.Interfaces;
using Addressbook.Models;
using Newtonsoft.Json;
using System.Diagnostics;


namespace Addressbook.Services;


/// <summary>
/// ContactService hanterar allt som rör kontakter och deras lagring
/// </summary>


public class ContactService : IContactService
{
    //Skapa en lista för att lagra kontakter:
    private List<IContact> contactList = new List<IContact>();
    //sökvägen till där vi vill att filen ska ligga
    private readonly FileService _fileService = new FileService(@"C:\Csharp-Projects\Adressbook\content.json");



    /*Lägg till en kontakt i listan genom AddContact-metoden. När användaren fyllt i alla uppgifter om kontakten i "AddContactOption-metoden" inuti "MenuService.cs" så 
   * anropas slutligen"AddContact-metoden" i ContactService.
   * Denna metoden tar emot en IContact-instans och lägger till den i vår "contacts-lista" och därmed vår "adressbok".*/
    public void AddContact(IContact contact)
    {

        try
        {
            //Här säger vi att endast om det inte finns någon kontakt i listan, så lägger vi in en kontakt (menas det att om det redan finns en kontakt så läggs den inte in? eller så menas det med att samma kontakt inte ska läggas in två gånger?
            if (!contactList.Any(x => x.Email == contact.Email))
            {
                contactList.Add(contact);

                var settings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                //sen vill vi spara listan:
                _fileService.SaveContentToFile(JsonConvert.SerializeObject(contactList, settings));



            }
        }
        catch (Exception ex) { Debug.Write(ex.Message); }


        Console.WriteLine("Contact added successfully!");
        Console.ReadKey(); // Vänta på användarens input innan du går tillbaka till menyn

    }

    public IEnumerable<IContact> GetAllContacts()
    {
        try
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var content = _fileService.GetContentFromFile();

            if (!string.IsNullOrEmpty(content))
            {

                contactList = JsonConvert.DeserializeObject<List<IContact>>(content, settings)!;

            }

        }
        catch (Exception ex) { Debug.Write(ex.Message); }
        return contactList;

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
        IContact contactToRemove = contactList.FirstOrDefault(c => c.Email == emailToRemove)!;

        if (contactToRemove != null)
        {
            contactList.Remove(contactToRemove);
            return true; // Returnera true för att indikera att kontakten har tagits bort
        }
        else
        {
            return false; // Returnera false för att indikera att ingen kontakt hittades med den angivna e-postadressen
        }
    }

    //public List<IContact> GetAllContacts()
    //{

    //    return contacts;

    //}

    public IContact GetContact(string emailToShow)
    {
        IContact contactToShow = contactList.FirstOrDefault(c => c.Email == emailToShow);

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