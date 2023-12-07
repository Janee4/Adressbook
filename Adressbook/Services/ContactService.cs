using System;
using System.Collections.Generic;
using Addressbook.Interfaces;
using Addressbook.Models;

namespace Addressbook.Services;


/// <summary>
/// ContactService hanterar allt som rör kontakter och deras lagring
/// </summary>
public interface IContactService

{
    //Lägg till en kontakt i listan genom AddContact-metoden.     
    void AddContact(IContact contact);
   

}



//Public eller internal?
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


    public List<IContact> GetAllContacts() 
    {
    
    return contacts;
    }
}
