
using Addressbook.Models;

namespace Addressbook.Models;



    //skapa en Interface som hanterar utskriften av menyn, den behöver inte returnera något så därav "void"
   public interface IMenuService
    {
        //skapa en metod som sköter utskriften av menyn
        void OptionsMenu();
        
    }



    //Denna klassen innehåller inga properties utan endast logiken för att utföra dessa metoder som den innehåller
    public class MenuService : IMenuService
    {
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

            switch(option)
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

        //Dessa metoder sätts som private för att de endast behöver nås ifrån MenuService klassen då bara den här klassen ska styra vilken meny som ska visas.
        private void AddContactOption()
        {

        //Instansiera en ny contact
        IContact contact = new Contact();
        DisplayMenuTitle("Add New Contact");
        Console.WriteLine("First Name: ");

        }

        private void AllContactsOption()
        {
            
        }

        private void RemoveContactOption()
        {
            
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
        private void DisplayMenuTitle (string title)
        {
        Console.Clear();
        Console.Write ($"### {title} ###");
        Console.WriteLine ();
        }

    }

internal interface IContact
{
}