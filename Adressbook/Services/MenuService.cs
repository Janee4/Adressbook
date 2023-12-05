
namespace Addressbook.Services;



    //skapa en Interface som hanterar utskriften av menyn, den behöver inte returnera något så därav "void"
   public interface IMenuService
    {
        //skapa en metod som sköter utskriften av menyn
        void ShowOptionsMenu();
        
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
                "\n3: Show All Contacts In The Addressbook" +
                "\n4: Exit Program");
                Console.Write("");
                Console.Write("Enter Menu Option");
            //användarens svar sparas i variabeln "option" och används sedan i switchen för att välja menyval
            var option = Console.ReadLine();

            switch(option)
            {

                case "1":
                    ShowAddContactOption();


                    break;

                case "2":
                    ShowRemoveContactOption();
                    break;

               case "3":
                    ShowAllContactsOption();
                    break;
               
                case "4":
                    false;
                    break;

                default:
                    break;





            }

                Console.ReadKey();

        }
    }

        //Dessa metoder sätts som private för att de endast behöver nås ifrån MenuService klassen då bara den här klassen ska styra vilken meny som ska visas.
        private void ShowAddContactOption()
        {
            throw new NotImplementedException();
        }

        private void ShowAllContactsOption()
        {
            throw new NotImplementedException();
        }

        private void ShowRemoveContactOption()
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




