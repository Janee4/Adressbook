using System;
using Addressbook.Interfaces;
using Addressbook.Services;
namespace Addressbook.Models;

/// <summary>
/// MenuService hanterar användargränssnittet och menyn
/// </summary>



//Denna klassen innehåller inga properties utan endast logiken för att utföra dessa metoder som den innehåller
public class MenuService : IMenuService
{
    //lägg till en ett privat fält för ContactService som lagrar en instans av ett objekt som implementerar IContactService som hanterar kontakter
    private IContactService contactService;

    public MenuService(IContactService contactService)
    {
        this.contactService = contactService;
    }

    public void OptionsMenu()
    {
        while (true)
        {
            Console.Clear();
            DisplayMenuTitle("MENU OPTIONS");
            Console.WriteLine(
                "\n1: Add Contact To The Addressbook" +
                "\n2: Remove Contact From The Addressbook" +
                "\n3: Show All Contacts In The Addressbook" +
                "\n4: Exit Program");
            Console.Write("");
            Console.Write("Enter Menu Option: ");
            //användarens svar sparas i variabeln "option" och används sedan i switchen för att välja menyval
            var option = Console.ReadLine();

            switch (option)
            {

                case "1":
                    AddContactOption();
                    break;

                case "2":
                    RemoveContactOption();
                    break;

                case "3":
                    AllContactsOption();
                    break;

                case "4":
                    ExitApplicationOption();
                    break;

                default:
                    Console.WriteLine("Invalid option. Press any key to see the menu again.");
                    Console.ReadKey();
                    break;

            }

        }
    }

    /// <summary>
    /// Dessa metoder sätts som private för att de endast behöver nås ifrån MenuService klassen då bara den här klassen ska styra vilken meny som ska visas.
    /// </summary>
    private void AddContactOption()
    {

        //Instansiera en ny contact från klassen Contact
        IContact contact = new Contact();
        DisplayMenuTitle("Add New Contact");
        Console.WriteLine("First Name: ");
        /*Spara in användarens värde av "FirstName" och lagra in den i "contact.FirstName" vilket kommer att spara in värdet i vår Contact klass 
         * (vi har ju properties där och användarens svar sparas in i dessa properties).*/

        //Med "!" lovar vi kompilatorn att jag som utvecklare tar på mig ansvaret att garantera att värdet inte är 'null', dvs det kommer att komma in ett svar som inte är null.
        contact.FirstName = Console.ReadLine()!;

        Console.WriteLine("Last Name: ");
        contact.LastName = Console.ReadLine()!;

        Console.WriteLine("E-mail: ");
        contact.Email = Console.ReadLine()!;

        Console.WriteLine("Phone number: ");
        contact.PhoneNumber = Console.ReadLine()!;

        Console.WriteLine("Adressinformation: ");
        contact.AddressInformation = Console.ReadLine()!;

        //Anropa AddContact-metoden i ContactService för att lägga till kontakten i listan:

        contactService.AddContact(contact);

    }

    public void RemoveContactOption()
    {
        DisplayMenuTitle("Remove Contact");

        Console.Write("Please type in the email address of the contact to remove: ");
        string emailToRemove = Console.ReadLine()!;

        // Anropa RemoveContact-metoden i ContactService för att försöka ta bort kontakten
        bool contactRemoved = contactService.RemoveContact(emailToRemove);

        if (contactRemoved)
        {
            Console.WriteLine("Contact removed successfully!");
        }
        else
        {
            Console.WriteLine($"Contact with email {emailToRemove} not found.");
        }

        Console.ReadKey();
    }

    private void AllContactsOption()
    {
        DisplayMenuTitle("The Adress book Contains The Following Contacts:");

        List<IContact> allContacts = contactService.GetAllContacts();

        foreach (IContact contact in allContacts) 
        {
        Console.WriteLine($"{contact}");
        }
        Console.ReadKey();
    }

   

    private void ExitApplicationOption()
    {
        Console.Clear();
        Console.Write("Are you sure you want to exit? (y/n): ");
        //Med "?? "" " så säger vi att om användaren inte skriver in något så får vi en tom sträng 
        var input = Console.ReadLine() ?? " ";
        //Oavsett om användaren skriver in Y med stor bokstav eller y med liten, så kommer programmet att stängas av.
        if (input.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }





    }
    //Skapa en metod som skriver ut titeln på menyn som du kan återanvända för varje option och lägga till valfri titel
    private void DisplayMenuTitle(string title)
    {
        Console.Clear();
        Console.Write($"### {title} ###");
        Console.WriteLine();
    }

}

