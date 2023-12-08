using Addressbook.Interfaces;
using System.Linq;

namespace Addressbook.Services;


/// <summary>
/// ContactService hanterar allt som rör kontakter och deras lagring
/// </summary>


public class ContactService : IContactService
{
    //Skapa en lista för att lagra kontakter:
    private List<IContact> contacts = new List<IContact>();

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
        IContact contactToRemove = contacts.FirstOrDefault(c => c.Email == emailToRemove);

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
}
