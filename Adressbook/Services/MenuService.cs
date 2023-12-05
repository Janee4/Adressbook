
namespace Adressbook.Services
{
    //skapa en Interface som hanterar utskriften av menyn, den behöver inte returnera något så därav "void"
   public interface IMenuService
    {
        //skapa en metod som sköter utskriften av menyn
        void ShowOptionsMenu();
        
        //Skapa en metod som visar alla kontakter
        void ShowAllPersonsOption ();

        //Skapa en metod som lägger till en kontakt
        void ShowAddPersonOption();

        //Skapa en metod som tar bort en kontakt 
        void ShowRemovePersonOption();
    }



    //Denna klassen innehåller inga properties utan endast logiken för att utföra dessa metoder som den innehåller
    public class MenuService : IMenuService
    {
        public void ShowAddPersonOption()
        {
            throw new NotImplementedException();
        }

        public void ShowAllPersonsOption()
        {
            throw new NotImplementedException();
        }

        public void ShowOptionsMenu()
        {
            throw new NotImplementedException();
        }

        public void ShowRemovePersonOption()
        {
            throw new NotImplementedException();
        }
    }
}
