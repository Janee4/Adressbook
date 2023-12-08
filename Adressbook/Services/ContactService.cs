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
