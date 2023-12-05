
namespace Addressbook.Services;



    //skapa en Interface som hanterar utskriften av menyn, den behöver inte returnera något så därav "void"
   public interface IMenuService
    {
        //skapa en metod som sköter utskriften av menyn
        void ShowOptionsMenu();
        
        //Skapa en metod som visar alla kontakter
        void ShowAllContactsOption ();

        //Skapa en metod som lägger till en kontakt
        void ShowAddContactOption();

        //Skapa en metod som tar bort en kontakt 
        void ShowRemoveContactOption();
    }



    //Denna klassen innehåller inga properties utan endast logiken för att utföra dessa metoder som den innehåller
    public class MenuService : IMenuService
    {
        public void ShowOptionsMenu()
        {
            while (true) 
            {
                Console.Clear();
            DisplayMenuTitle("MENU OPTIONS");
            Console.WriteLine(
                "\n1: Add Contact To The Addressbook" +
                "\n2: Remove Contact From The Addressbook" +
                "\n3: Show All Contacts In The Addressbook");

                Console.ReadKey();

        }
    }

        public void ShowAddContactOption()
        {
            throw new NotImplementedException();
        }

        public void ShowAllContactsOption()
        {
            throw new NotImplementedException();
        }

        public void ShowRemoveContactOption()
        {
            throw new NotImplementedException();
        }

        //Skapa en metod som skriver ut titeln på menyn som du kan återanvända för varje option och lägga till valfri titel
        private void DisplayMenuTitle (string title)
        {
        Console.Clear();
        Console.Write ($"### {title} ###");
        Console.WriteLine ();
        }

    }




