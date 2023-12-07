using System;
using System.Collections.Generic;
using Addressbook.Interfaces;
using Addressbook.Models;

namespace Addressbook.Services;


public interface IContactService

{

}



//Public eller internal?
public class ContactService : IContactService
{
    //Skapa en lista för att lagra kontakter:
    private List<IContact> contacts = new List<IContact>();


    /*Lägg till en kontakt i listan genom AddContact-metoden. När användaren fyllt i alla uppgifter om kontakten i "AddContactOption-metoden" anropas "AddContact-metoden" i ContactService.
     * Denna metoden tar emot en IContact-instans och lägger till den i vår "contacts-lista" och därmed vår "adressbok"*/
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
